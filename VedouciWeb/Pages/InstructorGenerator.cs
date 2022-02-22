using Microsoft.AspNetCore.Components;
using VedouciWeb.Models;

namespace VedouciWeb.Pages
{
    public partial class InstructorGenerator
    {
        private List<List<Together>> _possibleCombinations = new List<List<Together>>();

        private List<Instructor> _instructors = new List<Instructor>();
        private List<Instructor> _instructorsActive { get { return _instructors.Where(i => i.Active).ToList(); } }

        private List<Together> _together = new List<Together>();
        private List<Rule> _rules = new List<Rule>();

        // Settings
        private bool BoyAndGirl = true;
        private int MinYears = 2;

        private bool searching = false;

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
            Combinator.Instructors = this._instructors.Where(instr => instr.Active).ToList();
            Combinator.Together = this._together;
            Combinator.Rules = this._rules;

            Combinator.BoyAndGirl = BoyAndGirl;
            Combinator.MIN_YEARS_WITHOUT_EACH_OTHER = MinYears;

            this._possibleCombinations = await Combinator.MakeCombinations();
            searching = false;
        }


        private string womanColor(bool woman) => woman ? "pink" : "blue";
        private string activeColor(bool active) => active ? "green" : "red";

        private string getColor(int id) => Colorer.GetColorCode(id);

        private void ChangeActiveInstructor(int id)
        {
            var instructor = this._instructors.First(i => i.Id == id);
            instructor.Active = !instructor.Active;
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

            }
            catch
            {
                MinYears = 0;
            }

        }

        private void RemoveRule(Instructor a, Instructor b)
        {
            var rule = this._rules.FirstOrDefault(r => r.instructors.Contains(a) && r.instructors.Contains(b));
            if (rule != null)
                _rules.Remove(rule);
        }

        private void AddRule(Instructor a, Instructor b)
        {
            _rules.Add(new Rule(a, b));
        }
    }
}
