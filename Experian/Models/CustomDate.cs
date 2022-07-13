using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experian.Models
{
    public class CustomDate
    {
        private string _date;
        private int _numberOfDaysToadd;

        private int _year;
        private int _day;
        private int _month;

        public CustomDate(string _date, int _numberOfDaysToadd)
        {
            this._date = _date;
            this._numberOfDaysToadd = _numberOfDaysToadd;

            SplitDate();
        }

        public string AddDays()
        {
          
            //Temp Fix 
            if (_month == 12 && _day == 31)   return AddLastDaysDec();

            var currentMonth = _month;

            for (int i = 1; i < _numberOfDaysToadd; i++)
            {
                _day++;

                var numberOfDaysInMonth = GetNumberOfDays_InMonth(_month);

                if (_day > numberOfDaysInMonth)
                {
                    _month++;
                    _day = 1;

                    if (_month > 12)
                    {
                        _month = 1;
                        _year++;
                        _day = 1;
                    }
                }

            }

            if (currentMonth != 12)
            {
                _day++;

                if (_day > GetNumberOfDays_InMonth(_month))
                {
                    _month++;
                    _day = 1;

                    if (_month > 12)
                    {
                        _month = 1;
                        _year++;
                        _day = 1;
                    }
                }
                
                   
                
            }
                



            return addLeadingZeroToDay(_day) + "/" + addLeadingZeroToMonth(_month) + "/" + _year;
        }


        public string AddLastDaysDec()
        {
           
               
                    _day = 1;   //set day =1
                    _month = 1; //set month = 1
                    _year = _year + 1; //increase year by one

                return addLeadingZeroToDay(_day) + "/" + addLeadingZeroToMonth(_month) + "/" + _year;
            
               
            
           

           
        }


        public string invalidInput()
        {
            if(_month > 12)
            {
                return "Invalid Month";
            }
            if(_day > GetNumberOfDays_InMonth(_month))
            {
                return "Inavlid Day";
            }

            if(_year.ToString().Length < 4)
            {
                return "Inavlid year";
            }


            return "";
        }
    

        public string addLeadingZeroToDay(int _day)
        {
            if (_day < 10)
            {
                return "0" + _day.ToString();
            }

            return _day.ToString();
        }

        public string addLeadingZeroToMonth(int _month)
        {
            if (_month < 10)
            {
                return "0" + _month.ToString();
            }

            return _month.ToString();
        }


        public int GetYear()
        {
            return this._year;
        }

        private int GetNumberOfDays_InMonth(int _month)
        {
            if (_month % 2 == 0)
            {
                if (_month == 8)
                {
                    return 31;
                }
                if (_month == 2)
                {
                    if (IsItLeapYear() == true) return 29;

                    return 28;
                }

                return 30;
            }
            else
            {
                return 31;
            }


        }

        public int GetMonth()
        {
            return this._month;
        }

        public int GetDay()
        {
            return this._day;
        }

        private void SplitDate()
        {
            var splitDate = _date.Split('/');

            _year = int.Parse(splitDate[2]);
            _month = int.Parse(splitDate[1]);
            _day = int.Parse(splitDate[0]);
        }

        public bool IsItLeapYear()
        {
            if (this._year % 4 == 0)
            {
                if (this._year % 100 == 0)
                {
                    // if _year is divisible by 400, then the _year is a leap _year
                    if (_year % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }



        }
    }
}