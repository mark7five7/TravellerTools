﻿
namespace Grauenwolf.TravellerTools.Characters.Careers
{
    class Journalist : Entertainer
    {
        public Journalist(Book book) : base("Journalist", book) { }

        protected override string AdvancementAttribute => "Int";

        protected override int AdvancementTarget => 5;

        protected override string SurvivalAttribute => "Edu";

        protected override int SurvivalTarget => 7;

        internal override void AssignmentSkills(Character character, Dice dice)
        {

            switch (dice.D(6))
            {
                case 1:
                    {
                        var skillList = new SkillTemplateCollection();
                        skillList.Add("Art", "Holography");
                        skillList.Add("Art", "Write");
                        character.Skills.Increase(dice.Choose(skillList));
                    }
                    return;
                case 2:
                    character.Skills.Increase(dice.Choose(SpecialtiesFor("Electronics")));
                    return;
                case 3:
                    character.Skills.Increase(dice.Choose(SpecialtiesFor("Drive")));
                    return;
                case 4:
                    character.Skills.Increase("Investigate");
                    return;
                case 5:
                    character.Skills.Increase("Recon");
                    return;
                case 6:
                    character.Skills.Increase("Streetwise");
                    return;
            }

        }

        /// <summary>
        /// Titles the table.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="careerHistory">The career history.</param>
        /// <param name="dice">The dice.</param>
        internal override void TitleTable(Character character, CareerHistory careerHistory, Dice dice)
        {
            switch (careerHistory.Rank)
            {
                case 0:
                    return;
                case 1:
                    careerHistory.Title = "Freelancer";
                    character.Skills.Add("Electronics", "Comms", 1);
                    return;
                case 2:
                    careerHistory.Title = "Staff Writer";
                    character.Skills.Add("Investigate", 1);
                    return;
                case 3:
                    return;
                case 4:
                    careerHistory.Title = "Correspondent";
                    character.Skills.Add("Persuade", 1);
                    return;
                case 5:
                    return;
                case 6:
                    careerHistory.Title = "Senior Correspondent";
                    character.SocialStanding += 1;
                    return;
            }
        }
    }
}

