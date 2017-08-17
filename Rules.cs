using System;

namespace Patterns
{
     public interface IRule {
        int Order { get;  set; }
        bool Execute();
        bool IsMatch();
    }

    public class User {
        public string Name { get; set; }
        public uint Age { get; set; }
        public int Rate { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
    }

    

    public class RuleTest {
        User user = new User
        {
            Name = "Vasya",
            Age = 16,
            Rate = 80,
            Status = "Love Vodka",
            Phone = "06388554222"
        };

        IRule[] rules = new IRule[] { null };
    }


}