using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EFStartedBusinessLayer;

namespace EFStartedWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CRUD _crud= new CRUD();

        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxBlogs.ItemsSource = _crud.RetrieveAll();
        }


        private void ListBoxBlogs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxBlogs.SelectedItem != null)
            {
                ListBoxPosts.ItemsSource = _crud.RetrieveAllPosts(ListBoxBlogs.SelectedItem);
            }
        }

        private void ListBoxPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxPosts.SelectedItem != null)
            {
                _crud.SetPost(ListBoxPosts.SelectedItem);
                PopulatePosts();
            }
        }

        private void PopulatePosts()
        {
            if (_crud.selectedPost != null)
            {
                TextId.Text = _crud.selectedPost.PostId.ToString();
                TextTitle.Text = _crud.selectedPost.Title;
                TextContent.Text = _crud.selectedPost.Content;
              //  throw new NotImplementedException();
            }
        }

        private void Add_Blog_Button_Click(object sender, RoutedEventArgs e)
        {
            _crud.CreateBlog(TextNewBlogName.Text);
            ListBoxBlogs.ItemsSource = null;
            PopulateListBox();

        }

        private void Add_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            _crud.CreatePost(TextTitleNew.Text, TextContentNew.Text,ListBoxBlogs.SelectedItem);
            ListBoxPosts.ItemsSource = null;
            ListBoxPosts.ItemsSource = _crud.RetrieveAllPosts(ListBoxBlogs.SelectedItem);
            PopulatePosts(); 
        }

        private void Update_Post_Button_Click(object sender, RoutedEventArgs e)
        {
            _crud.UpdatePost(TextId.Text, TextTitle.Text, TextContent.Text);
            ListBoxPosts.ItemsSource = null;
            ListBoxPosts.ItemsSource = _crud.RetrieveAllPosts(ListBoxBlogs.SelectedItem);
            PopulatePosts(); 
        }

    }
}
