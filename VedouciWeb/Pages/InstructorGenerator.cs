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

        // Settings
        private bool BoyAndGirl = true;
        private int MinYears = 3;
        private int _maxComputeTime = 10;

        private bool searching = false;
        private bool timeExcited = false;

        protected override void OnInitialized()
        {
            BaseData.DefaultConfig();
            this._instructors = BaseData.Instructors;
            this._together = BaseData.Togethers;
            this._rules = BaseData.Rules;

            base.OnInitialized();
        }

        private async Task CalculateCombinations()
        {
            searching = true;
            timeExcited = false;
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


        private string womanColor(bool woman) => woman ? "red" : "blue";
        private string activeColor(bool active) => active ? "lime" : "grey";

        private string getColor(int id) => Colorer.GetColorCode(id);

        private void ChangeActiveInstructor(int id)
        {
            var activeInstructors = this._instructors.Count(i => i.Active);
            var instructor = this._instructors.First(i => i.Id == id);
            

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
            _rules.Add(new Rule(a, b));
        }

        private string AddRuleAuto(Instructor a, Instructor b)
        {
            if (!_rulesAuto.Any(r => r.MatchTheRule(a, b)))
                _rulesAuto.Add(new Rule(a, b));

            return "";
        }

    }
}
