using System;
using NullObject.Entities;

namespace NullObject.View
{
    public class LearnerView
    {
        private readonly ILearner _learner;

        public LearnerView(ILearner learner)
        {
            if(learner == null) throw new ArgumentNullException();
            if(learner.UserName == null) throw new ArgumentNullException();
            
            _learner = learner;
        }

        public void RenderView()
        {
            Console.WriteLine("User Name: " + _learner.UserName);
            Console.WriteLine("Courses Completed: " + _learner.CoursesCompleted);
        }
    }
}