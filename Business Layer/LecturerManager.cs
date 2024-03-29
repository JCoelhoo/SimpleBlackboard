﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;

namespace Business_Layer
{
    public class LecturerManager
    {
        public static int[] AllLecturerIds() //returns an array of all lecturer Id's
        {
            try
            {
                
                using (var context = new LecturerContext())
                {
                    var lecturerIDList = (from lecturer in context.Lecturers
                                          orderby lecturer.Lecturer_ID
                                          select lecturer.Lecturer_ID).ToList();
                    if(lecturerIDList!=null)
                    {
                        return lecturerIDList.ToArray();
                    }
                    return lecturerIDList.ToArray();
                }
            }
            catch (Exception e)
            {
                //log error 
                Console.Write(e);
                return null;
            }
        }
        public static Boolean AddLecturer(Lecturer lecturer, out string errorMessage) //for registration
        {
            errorMessage = "";
            Boolean checkEmail = checkExistingEmail(lecturer.Email, out errorMessage);
            if (checkEmail == false)
            {
                try
                {
                    using (var context = new LecturerContext())
                    {
                        context.Lecturers.Add(lecturer);
                        context.SaveChanges();
                        errorMessage = "";
                        return true; //Worked
                    }
                }
                catch (Exception e)
                {
                    errorMessage = "Database Problem";
                    return false;
                }
            }
            else
            {
                //Email Exists
                return false; // didnt work
            }
            //add try catch in controller
        }

        public static Lecturer getLecturerById(int Lecturer_ID)
        {
            try
            {
                Lecturer returnedLecturer = new Lecturer();
                using (var context = new LecturerContext())
                {
                    var lecturerResult = (from lecturer in context.Lecturers
                                          where lecturer.Lecturer_ID == Lecturer_ID
                                          select lecturer).FirstOrDefault();
                    if (lecturerResult != null)
                    {
                        returnedLecturer.Email = lecturerResult.Email;
                        returnedLecturer.Name = lecturerResult.Name;
                        returnedLecturer.Lecturer_ID = lecturerResult.Lecturer_ID;
                        returnedLecturer.Password = lecturerResult.Password;
                        returnedLecturer.Lecturer_ID = lecturerResult.Lecturer_ID;

                    }
                    return returnedLecturer;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
        public static Boolean checkExistingEmail(String email, out string errorMessage)
        {
            try
            {

                using (var context = new LecturerContext())
                {
                    var lecturerResult = (from lecturer in context.Lecturers
                                         where lecturer.Email == email
                                         select lecturer).FirstOrDefault();
                    if (lecturerResult != null)
                    {
                        errorMessage = "Email already Exists!";
                        return true; //email exists
                    }
                    errorMessage = "";
                    return false; //email doesnt exist
                }
            }
            catch (Exception e)
            {
                errorMessage = "Database Error When Retrieving Email!";
                return false; //db error
            }
        }
    }
}
