using Microsoft.AspNetCore.Components;
using VedouciWeb.Models;

namespace VedouciWeb.Pages
{
    public partial class InstructorGenerator
    {
        private List<Team> _possibleCombinations = new List<Team>();
        private double _possibleCombinationsTimeMs = 0;

        private List<Instructor> _instructors = new List<Instructor>();
        private List<Instructor> _instructorsActive { get { return _instructors.Where(i => i.Active).ToList(); } }

        private List<Together> _together = new List<Together>();
        private List<Rule> _rules = new List<Rule>();
        private List<Rule> _rulesAuto = new List<Rule>();

        private List<Team> _savedCombinations = new List<Team>();

        // Settings
        private bool BoyAndGirl = false;
        private int MinYears = 5;
        private int _maxComputeTime = 10;

        private bool searching = false;
        private bool timeExcited = false;

        private bool emptyLocalStorage = true;
        private DateTime localStorageTime = DateTime.MinValue;

        private bool ComputationError = false;
        private string ComputationErrorMessage = string.Empty;

        private bool boysAndGirlsCondition
        {
            get
            {
                if (BoyAndGirl)
                    return _instructors.Count(i => i.Woman && i.Active) > 3 && _instructors.Count(i => !i.Woman && i.Active) > 3;

                return true;
            }
        }


        protected override async void OnInitialized()
        {
            BaseData.DefaultConfig();
            this._instructors = BaseData.Instructors.OrderByDescending(i => i.Active).ThenBy(i => i.Year).ToList();
            this._together = BaseData.Togethers;
            this._rules = BaseData.Rules;

            try
            {
                localStorageTime = await localStore.GetItemAsync<DateTime>("time");
                var instructorsFromStorage = await localStore.GetItemAsync<List<Instructor>>("instructors");
                var rulesFromStorage = await localStore.GetItemAsync<List<List<Instructor>>>("rules");
                emptyLocalStorage = !instructorsFromStorage.Any();
            }
            catch
            {
                emptyLocalStorage = true;
            }

            base.OnInitialized();
        }

        private async Task CalculateCombinations()
        {
            searching = true;
            timeExcited = false;

            this.ComputationError = false;
            this.ComputationErrorMessage = string.Empty;

            if (this.BoyAndGirl && (this._instructors.Count(i => i.Active && i.Woman) < 4 || this._instructors.Count(i => i.Active && !i.Woman) < 4))
            {
                ComputationError = true;
                ComputationErrorMessage = "Není dostatek chlapců a dívek pro každý tým. Přidej dívky nebo chlapce, případně vypni pravidlo, že každý tým musí obsahovat chlapce i dívku.";
                return;
            }

            Combinator.Instructors = this._instructors.Where(instr => instr.Active).ToList();
            Combinator.Together = this._together;
            Combinator.Rules = new();
            Combinator.Rules.AddRange(this._rules);
            Combinator.Rules.AddRange(this._rulesAuto);
            Combinator.MAX_COMPUTE_TIME_SECONDS = _maxComputeTime;

            Combinator.BoyAndGirl = BoyAndGirl;
            Combinator.MIN_YEARS_WITHOUT_EACH_OTHER = MinYears;

            this._possibleCombinations = await Combinator.MakeCombinations();
            this._possibleCombinationsTimeMs = (Combinator.ComputationFinished - Combinator.ComputationStarted).TotalMilliseconds;
            this.timeExcited = Combinator.ComputationExcited;
            searching = false;
        }


        private async void SaveToLocalStorage()
        {
            this.localStorageTime = DateTime.Now;
            await localStore.SetItemAsync("time", this.localStorageTime);
            await localStore.SetItemAsync("instructors", this._instructors);
            await localStore.SetItemAsync("rules", this._rules.Select(r => r.instructors).ToList());
            await localStore.SetItemAsync("years", this.MinYears);
            await localStore.SetItemAsync("executionTime", this._maxComputeTime);
            emptyLocalStorage = false;
            this.StateHasChanged();
        }
        private async void LoadFromLocalStorage()
        {
            try
            {
                var instructorsFromStorage = await localStore.GetItemAsync<List<Instructor>>("instructors");
                var rulesFromStorage = await localStore.GetItemAsync<List<List<Instructor>>>("rules");

                foreach (var i in instructorsFromStorage)
                {
                    var localInstructor = this._instructors.First(inst => inst.Id == i.Id);
                    localInstructor.Woman = i.Woman;
                    localInstructor.Active = i.Active;
                }

                this._rules.Clear();
                foreach (var r in rulesFromStorage)
                {
                    Rule rule = new Rule();
                    foreach (var i in r)
                    {
                        rule.CannotBeTogether(_instructors.First(instr => instr.Id == i.Id));
                    }
                    _rules.Add(rule);
                }
            }
            catch
            {
                return;
            }

            this.StateHasChanged();
        }

        private async void ClearStorage()
        {
            await localStore.ClearAsync();
            emptyLocalStorage = true;
            this.StateHasChanged();
        }


        private string womanColor(bool woman) => woman ? "red" : "blue";
        private string activeColor(bool active) => active ? "#c9ffc9" : "#dddddd";

        private string getColor(int id) => Colorer.GetColorCode(id);

        private void ChangeActiveInstructor(int id)
        {
            var activeInstructors = this._instructors.Count(i => i.Active);
            var instructor = this._instructors.First(i => i.Id == id);

            this._rules.Where(r => r.instructors.Any(i => i.Id == id)).ToList().ForEach(r => this._rules.Remove(r));

            if (instructor.Active || activeInstructors < 12)
            {
                instructor.Active = !instructor.Active;
            }
        }

        private void ChangeGenderInstructor(int id)
        {
            var instructor = this._instructors.First(i => i.Id == id);
            instructor.Woman = !instructor.Woman;
        }

        private void BoyAndGirlSwitch()
        {
            BoyAndGirl = !BoyAndGirl;
        }

        private void MinYearChange(ChangeEventArgs args)
        {
            try
            {
                MinYears = Convert.ToInt32(args.Value);
                _rulesAuto = new List<Rule>();
                int limitYear = DateTime.Now.Year - MinYears - 1;
            }
            catch
            {
                MinYears = 0;
            }

        }

        private void MaxComputeTime(ChangeEventArgs args)
        {
            try
            {
                _maxComputeTime = Convert.ToInt32(args.Value);
            }
            catch
            {
                _maxComputeTime = 10;
            }

        }

        private void RemoveRule(Instructor a, Instructor b)
        {
            _rulesAuto = new List<Rule>();
            var rule = this._rules.FirstOrDefault(r => r.instructors.Contains(a) && r.instructors.Contains(b));
            if (rule != null)
                _rules.Remove(rule);
        }

        private void AddRule(Instructor a, Instructor b)
        {
            _rulesAuto = new List<Rule>();
            _rules.Add(new Rule(a, b, false));
        }

        private void AddRulePermit(Instructor a, Instructor b)
        {
            _rulesAuto = new List<Rule>();
            _rules.First(r => r.instructors.Contains(a) && r.instructors.Contains(b)).Together = true;
        }

        private string AddRuleAuto(Instructor a, Instructor b)
        {
            if (!_rulesAuto.Any(r => r.MatchTheRule(a, b)))
                _rulesAuto.Add(new Rule(a, b));

            return "";
        }

        private void ToggleCombination(Team t)
        {
            if (!this._savedCombinations.Exists(team => team.Fingerprint == t.Fingerprint))
                this._savedCombinations.Add(t);
            else
                this._savedCombinations.Remove(this._savedCombinations.First(team => team.Fingerprint == t.Fingerprint));
        }
    }
}
