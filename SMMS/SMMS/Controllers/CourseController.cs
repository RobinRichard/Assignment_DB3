﻿using SMMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMMS.Controllers
{
    public class CourseController : Controller
    {
        IN705_201802_arulr1Entities1 entities;

        public CourseController()
        {
            entities = new IN705_201802_arulr1Entities1();
        }

        //Course Level

        public ActionResult CourseLevel()
        {
            return View(entities.CourseLevels.ToList());
        }


        public ActionResult CourseAction(int? id)
        {
            if (id != 0)
            {
                CourseLevel dataset = entities.CourseLevels.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CourseAction(CourseLevel courselevel)
        {
            string msg = "";

            if (courselevel.CourseLevelID > 0)
            {
                var dataset = entities.CourseLevels.Where(f => f.CourseLevelID == courselevel.CourseLevelID).FirstOrDefault();
                if (dataset != null)
                {
                    dataset.LevelName = courselevel.LevelName;
                    msg = "Course Level Updated Successfully";
                }
            }
            else
            {
                entities.CourseLevels.Add(courselevel);
                msg = "New Course Level Added successfully";
            }
            entities.SaveChanges();
            TempData["msg"] = "<script>$(document).ready(function () {new PNotify({title: 'Success',text: '"+msg+"',type: 'success'});});</script>";
            return RedirectToAction("CourseLevel");

        }


        //Lesson Type

        public ActionResult LessonType()
        {
            return View(entities.LessonTypes.ToList());
        }


        public ActionResult LessonTypeAction(int? id)
        {
            if (id != 0)
            {
                LessonType dataset = entities.LessonTypes.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LessonTypeAction(LessonType lessontype)
        {
            string msg = "";

            if (lessontype.LessonTypeID > 0)
            {
                var dataset = entities.LessonTypes.Where(f => f.LessonTypeID == lessontype.LessonTypeID).FirstOrDefault();
                if (dataset != null)
                {
                    dataset.LessonName = lessontype.LessonName;
                    msg = "Lesson Type Updated Successfully";
                }
            }
            else
            {
                entities.LessonTypes.Add(lessontype);
                msg = "New Lesson Type Added successfully";
            }
            entities.SaveChanges();
            TempData["msg"] = "<script>$(document).ready(function () {new PNotify({title: 'Success',text: '" + msg + "',type: 'success'});});</script>";
            return RedirectToAction("LessonType");

        }

        //Instrument

        public ActionResult Instument()
        {
            return View(entities.Instruments.ToList());
        }


        public ActionResult InstumentAction(int? id)
        {
            if (id != 0)
            {
                Instrument dataset = entities.Instruments.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InstumentAction(Instrument instrument)
        {
            string msg = "";

            if (instrument.InstrumentID > 0)
            {
                var dataset = entities.Instruments.Where(f => f.InstrumentID == instrument.InstrumentID).FirstOrDefault();
                if (dataset != null)
                {
                    dataset.Name = instrument.Name;
                    dataset.Description = instrument.Description;
                    msg = "Instrument Updated Successfully";
                }
            }
            else
            {
                entities.Instruments.Add(instrument);
                msg = "New Instument Added successfully";
            }
            entities.SaveChanges();
            TempData["msg"] = "<script>$(document).ready(function () {new PNotify({title: 'Success',text: '" + msg + "',type: 'success'});});</script>";
            return RedirectToAction("Instument");

        }

        //Lesson

        public ActionResult Lesson()
        {
            return View(entities.Lessons.ToList());
        }


        public ActionResult LessonAction(int? id)
        {
            ViewBag.drpCourseLevel = CommonController.drpCourseLevel();
            ViewBag.drpInstrument = CommonController.drpInstrument();
            ViewBag.drpLessonType = CommonController.drpLessonType();

            if (id != 0)
            {
                Lesson dataset = entities.Lessons.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LessonAction(Lesson lesson)
        {
            string msg = "";

            if (lesson.LessonID > 0)
            {
                var dataset = entities.Lessons.Where(f => f.LessonID == lesson.LessonID).FirstOrDefault();
                if (dataset != null)
                {
                    dataset.Name = lesson.Name;
                    dataset.Description = lesson.Description;
                    dataset.CourseLevelID = lesson.CourseLevelID;
                    dataset.LessonTypeID = lesson.LessonTypeID;
                    dataset.InstrumentID = lesson.InstrumentID;
                    msg = "Lesson Updated Successfully";
                }
            }
            else
            {
                entities.Lessons.Add(lesson);
                msg = "New Lesson Added successfully";
            }
            entities.SaveChanges();
            TempData["msg"] = "<script>$(document).ready(function () {new PNotify({title: 'Success',text: '" + msg + "',type: 'success'});});</script>";
            return RedirectToAction("Lesson");

        }

        //Lesson

        public ActionResult Batch()
        {
            return View(entities.Lessonbatches.ToList());
        }


        public ActionResult BatchAction(int? id)
        {
            ViewBag.drpTutor = CommonController.drpTutor();
            ViewBag.drpLesson = CommonController.drpLesson();

            if (id != 0)
            {
                Lessonbatch dataset = entities.Lessonbatches.Find(id);
                return PartialView(dataset);
            }

            else
            {
                return PartialView();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BatchAction(Lessonbatch lesson)
        {
            string msg = "";

            if (lesson.LessonBatchID > 0)
            {
                var dataset = entities.Lessonbatches.Where(f => f.LessonBatchID == lesson.LessonBatchID).FirstOrDefault();
                if (dataset != null)
                {
                    dataset.Name = lesson.Name;
                    dataset.Duration = lesson.Duration;
                    dataset.StartTime = lesson.StartTime;
                    dataset.EndTime = lesson.EndTime;
                    dataset.Description = lesson.Description;
                    dataset.LessonID = lesson.LessonID;
                    dataset.TutorID = lesson.TutorID;
                    msg = "Lesson Batch Updated Successfully";
                }
            }
            else
            {
                entities.Lessonbatches.Add(lesson);
                msg = "New Lesson Batch Added successfully";
            }
            entities.SaveChanges();
            TempData["msg"] = "<script>$(document).ready(function () {new PNotify({title: 'Success',text: '" + msg + "',type: 'success'});});</script>";
            return RedirectToAction("Batch");

        }

    }
}