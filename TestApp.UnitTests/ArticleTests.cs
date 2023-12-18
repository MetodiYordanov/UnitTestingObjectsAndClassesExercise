using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;
    [SetUp]
    public void Setup()
    {
        this._article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] inputData = { "Article Content Author", "Article2 Content2 Author2", "Article3 Content3 Author3" };

        // Act
        Article result = this._article.AddArticles(inputData);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new List<Article>()
            {
                new Article()
                {
                    Author = "Some Author",
                    Content = "Some Content",
                    Title = "Title",
                },
                new Article()
                {
                    Author = "Some Author2",
                    Content = "Some Content2",
                    Title = "Title2",
                }
            }
        };
        string expected = $"Title - Some Content: Some Author{Environment.NewLine}" +
            $"Title2 - Some Content2: Some Author2";


        // Act
        string actual = this._article.GetArticleList(inputArticle, "title");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByAuthor()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new List<Article>()
            {
                new Article()
                {
                    Author = "Martin",
                    Content = "Some Content",
                    Title = "Title",
                },
                new Article()
                {
                    Author = "Ben",
                    Content = "Some Content2",
                    Title = "Title2",
                }
            }
        };
        string expected = $"Title2 - Some Content2: Ben{Environment.NewLine}" +
            $"Title - Some Content: Martin";


        // Act
        string actual = this._article.GetArticleList(inputArticle, "author");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new List<Article>()
            {
                new Article()
                {
                    Author = "Martin",
                    Content = "Old story",
                    Title = "Title",
                },
                new Article()
                {
                    Author = "Ben",
                    Content = "New story",
                    Title = "Title2",
                }
            }
        };
        string expected = $"Title2 - New story: Ben{Environment.NewLine}" +
            $"Title - Old story: Martin";


        // Act
        string actual = this._article.GetArticleList(inputArticle, "content");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        Article inputArticle = new Article()
        {
            ArticleList = new List<Article>()
            {
                new Article()
                {
                    Author = "Some Author",
                    Content = "Some Content",
                    Title = "Title",
                },
                new Article()
                {
                    Author = "Some Author2",
                    Content = "Some Content2",
                    Title = "Title2",
                }
            }
        };
        string expected = string.Empty;


        // Act
        string actual = this._article.GetArticleList(inputArticle, "no-citeria");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
