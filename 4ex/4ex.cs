using System;
using System.Collections.Generic;

internal class Program
{
    delegate void Create(string smth);
    abstract class Emploee
    {
        private int hours;
        public virtual int GetHours()
        {
            return hours;
        }
        public virtual void SetName(string smth)
        {
        }
        public virtual string GetName()
        {
            return "a";
        }
    }
    class PartTimeEmployee: Emploee { 
        private int hours = 20;
        private string name;
        public override void SetName(string smth)
        {
            name= smth;
        }
        public override string GetName()
        {
            return name;
        }
        public override int GetHours()
        {
            return hours;
        }

    }
    class StandardEmployee: Emploee
    {
        private string name;
        private int hours = 40;

        public override void SetName(string smth)
        {
            name = smth;
        }
        public override string GetName()
        {
            return name;
        }

        public override int GetHours()
        {
            return hours;
        }

    }

    class Job
    {
        private int hours;
        private string Name { get; set; }

        Emploee emp;

        public Job(string name, int hour, Emploee a)
        {
            Name = name;
            hours = hour;
            emp = a;
        }

        public void PassWeek()
        {
            hours -= emp.GetHours();
        }

        public int Status()
        {
            if (hours <= 0)
            {
                Console.WriteLine(Name+" is done");
                return 1;
            }
            else
            {
                Console.WriteLine(Name + " Hours Remaining: "+hours);
                return 0;
            }
        }
    }
    static void Main()
    {
        List<Emploee> workers=new List<Emploee>();
        List<Job> jobs = new List<Job>();

        while (true)
        {
            var all = Console.ReadLine().Split();

            if (all[0] == "StandardEmployee")
            {
                
                StandardEmployee temp = new StandardEmployee();
                temp.SetName(all[1]);

                workers.Add(temp);
            }
            else if (all[0] == "PartTimeEmployee")
            {
                
                PartTimeEmployee temp = new PartTimeEmployee();
                temp.SetName(all[1]);

                workers.Add(temp);
            }
            else if (all[0] == "Job")
            {

                foreach (Emploee em in workers)
                {
                    if (em.GetName() == all[3])
                    {
                        Job temp = new Job(all[1], int.Parse(all[2]), em);
                        jobs.Add(temp);
                    }
                }

            }
            else if (all[0] == "Pass")
            {
                foreach (Job temp in jobs)
                {
                    temp.PassWeek();
                }
            }
            else if (all[0] == "Status")
            {
                int k = 0;
                foreach (Job temp in jobs)
                {
                    int i = temp.Status();
                    if (i == 1)
                    {
                        jobs.RemoveAt(k);
                        break;
                    }
                    k++;
                }
            }
            else if (all[0] == "END")
            {
                break;
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
