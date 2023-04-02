﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteDocTruyen.Models;
using System.Data.Entity;

namespace WebsiteDocTruyen.Controllers
{
    public class ChaptersController : Controller
    {
        public readonly ApplicationDbContext _dbContext;
        public ChaptersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Chapters
        // hiện chapter của từng truyện
        public ActionResult ChapterOfStory(int storyId)
        {
            var story = _dbContext.Stories.Include(s => s.Chapters).SingleOrDefault(s => s.StoryID == storyId);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

    }
}