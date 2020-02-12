using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Http.News.Data.Contracts;
using Http.News.Data.Contracts.Entities;
using Http.News.Data.EntityFramework;
using Http.News.Domain.Services;
using Microsoft.AspNet.SignalR;

namespace ITNewsWeb.Models
{
    public class CommentsHub : Hub
    {
        private readonly INewsRepository _repository = new NewsRepository(new NewsDbContext());

        public void Send(string name, string message, int itemId)
        {
            Clients.All.AddNewMessageToPage(name, message);
            _repository.Add(new Comment { ItemId = itemId, Author = name, Content = message });
            _repository.Save();
        }

        public void InitPage(int itemId)
        {
            var comments = _repository.GetAllComments();
            foreach (var comment in comments)
            {
                if (comment.ItemId == itemId)
                {
                    Clients.All.AddNewMessageToPage(comment.Author, comment.Content);
                }
            }
        }
    }
}