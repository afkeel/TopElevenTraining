﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TrainingCalculator;

namespace RooterTests
{
    using PA = PlayerAttribute;
    [TestClass]
    public class TrainingCalculatorTest
    {
        static PA.Attributes[] PASS_GO_AND_SHOOT = { PA.Attributes.Passing, PA.Attributes.Shooting, PA.Attributes.Speed };
        static PA.Attributes[] FAST_COUNTER_ATTACKS = { PA.Attributes.Passing, PA.Attributes.Crossing, PA.Attributes.Finishing, PA.Attributes.Creativity };
        static PA.Attributes[] SKILL_DRILL = { PA.Attributes.Heading, PA.Attributes.Dribling, PA.Attributes.Creativity };
        static PA.Attributes[] SHOOTING_TECHNIQUE = { PA.Attributes.Shooting, PA.Attributes.Finishing, PA.Attributes.Strength };
        static PA.Attributes[] SET_PIECE_DELIVERY = { PA.Attributes.Marking, PA.Attributes.Heading, PA.Attributes.Crossing, PA.Attributes.Shooting };
        static PA.Attributes[] SLALOM_DRIBBLE = { PA.Attributes.Passing, PA.Attributes.Dribling, PA.Attributes.Fitness, PA.Attributes.Speed };
        static PA.Attributes[] WING_PLAY = { PA.Attributes.Heading, PA.Attributes.Crossing, PA.Attributes.Shooting, PA.Attributes.Finishing };
        static PA.Attributes[] ONE_ON_ONE_FINISHING = { PA.Attributes.Tackling, PA.Attributes.Dribling, PA.Attributes.Finishing };

        [TestMethod]
        public void Test_IncreasePlayerAttribute()
        {
            List<PA> actual = new List<PA>();
            actual.Add(new PA(PA.Attributes.Tackling, PA.Color.GRAY, 20));
            actual.Add(new PA(PA.Attributes.Marking, PA.Color.GRAY, 20));
            actual.Add(new PA(PA.Attributes.Positioning, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Heading, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Bravery, PA.Color.GRAY, 20));

            actual.Add(new PA(PA.Attributes.Passing, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Dribling, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Crossing, PA.Color.GRAY, 20));
            actual.Add(new PA(PA.Attributes.Shooting, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Finishing, PA.Color.WHITE, 60));

            actual.Add(new PA(PA.Attributes.Fitness, PA.Color.GRAY, 20));
            actual.Add(new PA(PA.Attributes.Strength, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Aggression, PA.Color.GRAY, 20));
            actual.Add(new PA(PA.Attributes.Speed, PA.Color.WHITE, 60));
            actual.Add(new PA(PA.Attributes.Creativity, PA.Color.WHITE, 60));

            CalculationAttributes testClass = new CalculationAttributes();
            List<double> expected = new List<double>() 
            {
                48.5,20.0,60.0,153.0,20.0,
                290.0,240.0,60.0,233.0,250.0,
                35.0,113.0,20.0,210.0,233.0
            };
            
            List<Drill> listDrill = new List<Drill>();
            listDrill.Add(new Drill("PASS_GO_AND_SHOOT", PASS_GO_AND_SHOOT));
            listDrill.Add(new Drill("FAST_COUNTER_ATTACKS", FAST_COUNTER_ATTACKS));
            listDrill.Add(new Drill("SKILL_DRILL", SKILL_DRILL));
            listDrill.Add(new Drill("SHOOTING_TECHNIQUE", SHOOTING_TECHNIQUE));
            listDrill.Add(new Drill("SET_PIECE_DELIVERY", SET_PIECE_DELIVERY));
            listDrill.Add(new Drill("SLALOM_DRIBBLE", SLALOM_DRIBBLE));
            listDrill.Add(new Drill("WING_PLAY", WING_PLAY));
            listDrill.Add(new Drill("ONE_ON_ONE_FINISHING", ONE_ON_ONE_FINISHING));

            testClass.IncreasePlayerAttribute(actual, listDrill);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i].ValueAttribute);
            }           
        }
        public void Test_SwapDrill()
        {
            CalculationAttributes testClass = new CalculationAttributes();
            List<Drill> listDrill = new List<Drill>();
            listDrill.Add(new Drill("PASS_GO_AND_SHOOT", PASS_GO_AND_SHOOT));
            listDrill.Add(new Drill("FAST_COUNTER_ATTACKS", FAST_COUNTER_ATTACKS));
            listDrill.Add(new Drill("SKILL_DRILL", SKILL_DRILL));
            listDrill.Add(new Drill("SHOOTING_TECHNIQUE", SHOOTING_TECHNIQUE));
            listDrill.Add(new Drill("SET_PIECE_DELIVERY", SET_PIECE_DELIVERY));
            listDrill.Add(new Drill("SLALOM_DRIBBLE", SLALOM_DRIBBLE));
            listDrill.Add(new Drill("WING_PLAY", WING_PLAY));
            listDrill.Add(new Drill("ONE_ON_ONE_FINISHING", ONE_ON_ONE_FINISHING));

            int index = 0;
            for (int i = 0; i < 24; i++)
            {
                testClass.SwapDrill(listDrill, index);
                if (index >= listDrill.Count - 1)
                    index = 0;
            }
        }

    }
}