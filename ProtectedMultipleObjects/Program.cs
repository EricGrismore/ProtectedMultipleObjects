using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography;
using System.Transactions;

namespace Inheritance
{
    class CookieInc
    {
        protected int _CookieId;
        protected string _FirstName;
        protected string _LastName;
        protected int _Amount;

        public CookieInc()
        {
            _CookieId = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Amount = 0;
        }

        public CookieInc(int cookie, string firstName, string lastName, int amount)
        {
            _CookieId = cookie;
            _FirstName = firstName;
            _LastName = lastName;
            _Amount = amount;
        }
        public virtual void addChange()
        {
            Console.Write("COOKIEID=");
            _CookieId=int.Parse(Console.ReadLine());

            Console.Write("First Name=");
            _FirstName=Console.ReadLine();

            Console.Write("Last Name=");
            _LastName=Console.ReadLine();

            Console.Write("Amount of cookies=");
            _Amount=int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"ID:");
            Console.WriteLine($"Name:");
            Console.WriteLine($"Age:");
        }
    }
    class CEmployer : CookieInc
    {
        protected int _ECookie;
        protected string _EName;

        public CEmployer()
        {
            _EName = string.Empty;
            _ECookie = 0;
            _CookieId = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Amount = 0;
        }
        public CEmployer(int cookieid, string firstname, string lastname, int amount, int Ecookie, string Ename)
            : base(cookieid, firstname, lastname, amount)
        {
            _ECookie = Ecookie;
            _EName = Ename;
            _CookieId = cookieid;
            _FirstName = firstname;
            _LastName = lastname;
            _Amount = amount;
        }
        public override void addChange()
        {
            Console.WriteLine("Managment Information");
            Console.Write("Cookies=");
            _ECookie=int.Parse(Console.ReadLine());

            Console.Write("COOKIEID=");
            _CookieId = int.Parse(Console.ReadLine());

            Console.Write("First Name=");
            _FirstName = Console.ReadLine();

            Console.Write("Last Name=");
            _LastName = Console.ReadLine();

            Console.Write("Employers Name=");
            _EName=Console.ReadLine();

            Console.Write("Amount of cookies=");
            _Amount=int.Parse(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($"  Amount Of Cookies Get: {_ECookie}");
            Console.WriteLine($"Employers Name: {_EName}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"ID: {_CookieId}");
            Console.WriteLine($"Name: {_FirstName} {_LastName}");
            Console.WriteLine($"Age: {_Amount}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many cookies do you want?");
            int chocolate;
            while (!int.TryParse(Console.ReadLine(), out chocolate))
                Console.WriteLine("Please enter a whole number");


            CookieInc[] emps = new CookieInc[chocolate];
            Console.WriteLine("How many cookies are being make per purchase?");
            int raisin;
            while (!int.TryParse(Console.ReadLine(), out raisin))
                Console.WriteLine("Please enter a whole number");

            CEmployer[] mgr = new CEmployer[raisin];

            int Number, C2, C3;
            int raiCounter = 0, cooCounter = 0;
            Number = Menu();
            while (Number != 4)
            {
                Console.WriteLine("Enter 1 for Buying or 2 for Making");
                while (!int.TryParse(Console.ReadLine(), out C3))
                    Console.WriteLine("1 for Buying or 2 for Making");
                try
                {
                    switch (Number)
                    {
                        case 1:
                            if (C3 == 1)
                            {
                                if (cooCounter <= raisin)
                                {
                                    mgr[cooCounter] = new CEmployer();
                                    mgr[cooCounter].addChange();
                                    cooCounter++;
                                }
                                else
                                    Console.WriteLine("The max number of cookies are being made");

                            }
                            else
                            {
                                if (raiCounter <= chocolate)
                                {
                                    emps[raiCounter] = new CookieInc();
                                    emps[raiCounter].addChange();
                                    raiCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of cookies are being bought");
                            }

                            break;
                        case 2:
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out C2))
                                Console.Write("Enter the record number you want to change: ");
                            C2--;
                            if (C3 == 1)
                            {
                                while (C2 > cooCounter - 1 || C2 < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out C2))
                                        Console.Write("Enter the record number you want to change: ");
                                    C2--;
                                }
                                mgr[C2].addChange();
                            }
                            else
                            {
                                while (C2 > raiCounter - 1 || C2 < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out C2))
                                        Console.Write("Enter the record number you want to change: ");
                                    C2--;
                                }
                                emps[C2].addChange();
                            }
                            break;
                        case 3:
                            if (C3 == 1)
                            {
                                for (int i = 0; i < cooCounter; i++)
                                    mgr[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < raiCounter; i++)
                                    emps[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Number = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}