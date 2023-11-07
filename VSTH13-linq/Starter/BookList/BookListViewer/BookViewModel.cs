﻿using BookList.Library;
using System.ComponentModel;

namespace BookListViewer;

public class BookViewModel : INotifyPropertyChanged
{
    // TODO READ indicator

    private static readonly KeyValuePair<string, string>[] sortList = {
        new KeyValuePair<string, string>("Author", "Author"),
        new KeyValuePair<string, string>("Title", "Title"),
        new KeyValuePair<string, string>("OriginalPublicationYear", "Publication Year"),
    };

    public KeyValuePair<string, string>[] SortList
    {
        get
        {
            return sortList;
        }
    }

    private static readonly KeyValuePair<string, string>[] groupList = {
        new KeyValuePair<string, string>("None", "None"),
        new KeyValuePair<string, string>("Author", "Author"),
        new KeyValuePair<string, string>("OriginalPublicationYear", "Publication Year"),
    };

    public KeyValuePair<string, string>[] GroupList
    {
        get
        {
            return groupList;
        }
    }

    private BookTemplate listTemplate = BookTemplate.FlatAuthor;
    public BookTemplate ListTemplate
    {
        get { return listTemplate; }
        set { listTemplate = value; }
    }


    private IEnumerable<Book>? books;
    public IEnumerable<Book> Books
    {
        get => books ?? Loader.LoadJsonData(AppDomain.CurrentDomain.BaseDirectory + "book_list.json").Where(b => b.Bookshelves?.Contains("owned-sci-fi") ?? false);
    }

    private dynamic displaybooks;
    public dynamic DisplayBooks
    {
        get { return displaybooks; }
        set { displaybooks = value; }
    }

    private string searchText = "";
    public string SearchText
    {
        get { return searchText; }
        set { searchText = value; UpdateFilterAndSort(); }
    }

    private bool limitTo1970s = false;
    public bool LimitTo1970s
    {
        get { return limitTo1970s; }
        set { limitTo1970s = value; UpdateFilterAndSort(); }
    }

    private string? primarySort = "Author";
    public string? PrimarySort
    {
        get { return primarySort; }
        set { primarySort = value; UpdateFilterAndSort(); }
    }

    private string? secondarySort = "Title";
    public string? SecondarySort
    {
        get { return secondarySort; }
        set { secondarySort = value; UpdateFilterAndSort(); }
    }

    private string? tertiarySort = "OriginalPublicationYear";
    public string? TertiarySort
    {
        get { return tertiarySort; }
        set { tertiarySort = value; UpdateFilterAndSort(); }
    }

    private string? grouping = "None";
    public string? Grouping
    {
        get { return grouping; }
        set { grouping = value; primarySort = value; UpdateFilterAndSort(); }
    }

    private IEnumerable<Book> filtered;
    public int BookCount => filtered.Count();

    public BookViewModel()
    {
        ResetFilterAndSort();
    }

    public void ResetFilterAndSort()
    {
        searchText = "";
        limitTo1970s = false;
        grouping = "None";
        primarySort = "Author";
        secondarySort = "Title";
        tertiarySort = "OriginalPublicationYear";
        UpdateFilterAndSort();
    }

    public void UpdateFilterAndSort()
    {
        filtered = UpdateFilter(Books);
        var sorted = UpdateSort(filtered, PrimarySort, SecondarySort, TertiarySort);
        switch (Grouping)
        {
            case "Author":
                displaybooks = sorted.GroupBy(b => b.Author);
                listTemplate = SecondarySort switch
                {
                    "Title" => BookTemplate.AuthorTitleGroup,
                    "OriginalPublicationYear" => BookTemplate.AuthorYearGoup,
                    _ => BookTemplate.AuthorTitleGroup,
                };
                break;
            case "OriginalPublicationYear":
                displaybooks = sorted.GroupBy(b => b.OriginalPublicationYear.ToString());
                listTemplate = SecondarySort switch
                {
                    "Author" => BookTemplate.YearAuthorGroup,
                    "Title" => BookTemplate.YearTitleGroup,
                    _ => BookTemplate.YearAuthorGroup
                };
                break;
            default:
                displaybooks = sorted;
                listTemplate = PrimarySort switch
                {
                    "Author" => BookTemplate.FlatAuthor,
                    "Title" => BookTemplate.FlatTitle,
                    "OriginalPublicationYear" => BookTemplate.FlatYear,
                    _ => BookTemplate.FlatAuthor
                };
                break;
        }
        RaisePropertyChanged();
    }

    private IEnumerable<Book> UpdateFilter(IEnumerable<Book> data)
    {
        if (limitTo1970s)
            data = data.Where(b => b.OriginalPublicationYear >= 1970 && b.OriginalPublicationYear <= 1979);

        if (string.IsNullOrEmpty(SearchText.Trim())) return data;
        return data
            .Where(b => b.Author.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                     || b.Title.Contains(searchText, StringComparison.CurrentCultureIgnoreCase));
    }

    private IOrderedEnumerable<Book> UpdateSort(IEnumerable<Book> data, string? primary, string? secondary = null, string? tertiary = null)
    {
        var sorted = primary switch
        {
            "Author" => data.OrderBy(b => b.Author),
            "Title" => data.OrderBy(b => b.Title, new BookTitleComparer()),
            "OriginalPublicationYear" => data.OrderBy(b => b.OriginalPublicationYear),
            _ => data.OrderBy(b => b.Author)
        };

        if (secondary is not null)
            sorted = secondary switch
            {
                "Author" => sorted.ThenBy(b => b.Author),
                "Title" => sorted.ThenBy(b => b.Title, new BookTitleComparer()),
                "OriginalPublicationYear" => sorted.ThenBy(b => b.OriginalPublicationYear),
                _ => sorted
            };

        if (tertiary is not null)
            sorted = tertiary switch
            {
                "Author" => sorted.ThenBy(b => b.Author),
                "Title" => sorted.ThenBy(b => b.Title, new BookTitleComparer()),
                "OriginalPublicationYear" => sorted.ThenBy(b => b.OriginalPublicationYear),
                _ => sorted
            };

        return sorted;
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler? PropertyChanged;
    private void RaisePropertyChanged(string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}
