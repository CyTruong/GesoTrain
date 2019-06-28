using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using System.Data.Entity;


namespace web.Controllers
{
    public class HomeController : Controller
    {
        private CV_MVCEntities db = new CV_MVCEntities();
        private const int FROM_YEAR = 1980;
        private const int TO_YEAR = 2020;
        private UserModel model;



        public ActionResult Userpage()
        {
            model = new UserModel();
            model.student = db.STUDENT.Find(1);

            #region Load Name of Fau
            String fau_name = "";
            if (model.student.FACULTIES_FK != 0)
            if (db.FACULTIES.Any(fau => (fau.ID == model.student.FACULTIES_FK)))
            {
                fau_name = (from fau in db.FACULTIES where fau.ID == model.student.FACULTIES_FK select fau).ToList()[0].NAME;
            }

            #endregion

            #region load Kinh nghiệm làm việc
            model.studenEXP = new List<STUDENT_EXPERIENCE>();

            if (model.student != null)
            {
                foreach (STUDENT_EXPERIENCE stuEx in model.studenEXP)
                {
                    stuEx.STUDENT_FK = model.student.ID;
                }
            }

            if (db.STUDENT_EXPERIENCE.Any(exp => (exp.STUDENT_FK == model.student.ID)))
            {
                model.studenEXP = (from exp in db.STUDENT_EXPERIENCE where exp.STUDENT_FK == model.student.ID select exp).ToList();
            }
            model.school = db.SCHOOL.Find(model.student.SCHOOL_FK);

            model.studenEXP.Add(new STUDENT_EXPERIENCE());
            #endregion

            #region load kĩ nămg

            model.skillList = db.SKILL.ToList();
            List<STUDENT_SKILL> stu_skill_arr = new List<STUDENT_SKILL>();
            stu_skill_arr = (from skill in db.STUDENT_SKILL where skill.STUDENT_FK == model.student.ID select skill).ToList();
            if (stu_skill_arr != null)
            {
                foreach (STUDENT_SKILL stu_skill in stu_skill_arr)
            {
                for (int i = 0; i< model.skillList.Count; i++)
                {
                    if (stu_skill.SKILL_FK == model.skillList[i].ID)
                    {
                        model.skillList[i].isChecked = true;
                    }
                }
            }

            }

            #endregion
           
            #region load sở thích
            model.cvStudent = new CV_STUDENT();
            if (db.CV_STUDENT.Any(exp => (exp.STUDENT_FK == model.student.ID)))
            {
                model.cvStudent = (from cv in db.CV_STUDENT where cv.STUDENT_FK == model.student.ID select cv).ToList()[0];
            }
            #endregion
            
            #region Month Year

            List<int> month = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                month.Add(i);
            }
            List<int> year = new List<int>();
            for (int i = TO_YEAR; i >= FROM_YEAR; i--)
            {
                year.Add(i);
            }
            #endregion

            #region creat selection
            SelectList trinhdo = new SelectList(new List<SelectListItem>
            {
                  new SelectListItem { Text = "Đại học", Value = "1"},
                  new SelectListItem {  Text = "Cao Đẳng", Value = "2"},
                  new SelectListItem {  Text = "Tự do", Value = "3"}

            },"Value","Text");

          
            List<FACULTIES> listFaulties = new List<FACULTIES>();
            listFaulties = (from fau in db.FACULTIES where fau.SCHOOL_FK == model.student.SCHOOL_FK select fau).ToList();
            List<SelectListItem> selectListFau = new List<SelectListItem>();
            for (int i = 0; i < listFaulties.Count; i++)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = listFaulties[i].NAME,
                    Value = listFaulties[i].ID.ToString()
                };
                selectListFau.Add(item);
            }


            List<SCHOOL> listSchool = new List<SCHOOL>();
            listSchool = db.SCHOOL.ToList();
            List<SelectListItem> selectListsSchool = new List<SelectListItem>();
            for (int i = 0; i < listSchool.Count; i++)
            {
                SelectListItem schoolitem = new SelectListItem
                {
                    Text = listSchool[i].NAME,
                    Value = listSchool[i].ID.ToString()
                };
                selectListsSchool.Add(schoolitem);
            }
            #endregion

            ViewBag.stu_fau = fau_name;
            ViewBag.list_school = selectListsSchool;
            ViewBag.fau = selectListFau;
            ViewBag.trinhdo = trinhdo;
            ViewBag.stuid = model.student.ID;
            ViewBag.monthSelectList = new SelectList(month);
            ViewBag.yearSelectList = new SelectList(year);
            ViewBag.lastStuExp = model.studenEXP.Count - 1;
            //CÔng việc tiếp theo , tạo drow view cho tháng và năm
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateEXP")]
        public ActionResult CreateEXP([Bind(Include = "student,studenEXP,skillList,cvStudent,school")] UserModel UserModel)
        {

            UserModel.studenEXP[UserModel.studenEXP.Count - 1].STUDENT_FK = UserModel.student.ID;
            if (ModelState.IsValid)
            {
                db.Entry(UserModel.studenEXP[UserModel.studenEXP.Count - 1]).State = EntityState.Added;
                db.SaveChanges();
            }
            return Redirect("/Home/Userpage");
        }

        [HttpPost]
        [ActionName("UpdateStuSkill")]
        public ActionResult UpdateStuSkill([Bind(Include = "student,skillList,cvStudent")] UserModel UserModel)
        {
            int id = UserModel.student.ID;
            List<STUDENT_SKILL> current_stu_skil = new List<STUDENT_SKILL>();
            if (db.STUDENT_SKILL.Any(exp => (exp.STUDENT_FK == id)))
            {
                current_stu_skil = (from exp in db.STUDENT_SKILL where exp.STUDENT_FK == id select exp).ToList();
            }
            /*  
             * check có + data có : nop
             * check có + data ko : add
             * check ko + data có : delete
             * check ko + data ko : nop
             */
            foreach (SKILL chk_skill in UserModel.skillList)
            {
                foreach (STUDENT_SKILL stu_skill in current_stu_skil)
                {
                    if (stu_skill.SKILL_FK == chk_skill.ID)
                    {
                        if (chk_skill.isChecked && !stu_skill_ishave(stu_skill.SKILL_FK, current_stu_skil))
                        {
                            STUDENT_SKILL sTUDENT_SKILL = new STUDENT_SKILL();
                            sTUDENT_SKILL.STUDENT_FK = id;
                            sTUDENT_SKILL.SKILL_FK = chk_skill.ID;
                            db.STUDENT_SKILL.Add(sTUDENT_SKILL);
                            db.SaveChanges();
                        }
                        else
                            if (!chk_skill.isChecked && stu_skill_ishave(stu_skill.SKILL_FK, current_stu_skil))
                        {
                            STUDENT_SKILL sTUDENT_SKILL = db.STUDENT_SKILL.Find(stu_skill.ID);
                            db.STUDENT_SKILL.Remove(sTUDENT_SKILL);
                            db.SaveChanges();
                        }
                    }
                }
                if (!stu_skill_ishave(chk_skill.ID, current_stu_skil)&&chk_skill.isChecked)
                {
                    STUDENT_SKILL sTUDENT_SKILL1 = new STUDENT_SKILL();
                    sTUDENT_SKILL1.STUDENT_FK = id;
                    sTUDENT_SKILL1.SKILL_FK = chk_skill.ID;
                    db.STUDENT_SKILL.Add(sTUDENT_SKILL1);
                    db.SaveChanges();
                }
            }
            if (ModelState.IsValid)
            {
                UserModel.cvStudent.STUDENT_FK = UserModel.student.ID;
                if (db.CV_STUDENT.Any(exp => (exp.STUDENT_FK == UserModel.student.ID)))
                {
                    db.Entry(UserModel.cvStudent).State = EntityState.Modified;

                }else
                {
                    db.Entry(UserModel.cvStudent).State = EntityState.Added;
                }
                db.SaveChanges();
            }

            return Redirect("/Home/Userpage");

        }

        private bool stu_skill_ishave(int id, List<STUDENT_SKILL> arr)
        {
            foreach (STUDENT_SKILL stu_skill in arr)
            {
                if (stu_skill.SKILL_FK == id)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        [ActionName("UpdateStuTrain")]
        [ValidateAntiForgeryToken]

        public ActionResult UpdateStuTrain([Bind(Include = "student,school")] UserModel UserModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(UserModel.student).State = EntityState.Modified;
                db.Entry(UserModel.school).State = EntityState.Modified;
                db.SaveChanges();            
            }
            return Redirect("/Home/Userpage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}