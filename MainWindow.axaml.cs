using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AvaloniaCSharp.Entities;
using System.Linq;
using Avalonia.Interactivity;
using System.IO;


namespace AvaloniaCSharp;

public partial class MainWindow : Window
{
    public PostgresContext context;
    public List<Clienty> ClientyData { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        context = new PostgresContext();
        ShowData();
    }

    public void ShowData()
    {
        var ClientyData = context.Clienties
                                    .ToList();

        ListData.ItemsSource = ClientyData;
    }

    public void BtnUP(Object Sender, RoutedEventArgs e)
    {
        MainWindow frm = new MainWindow();
        frm.Show();
        this.Hide();
    }

    public void BtnSearch(Object Sender, RoutedEventArgs e)
    {
        var namevar = this.FindControl<TextBox>("nametext");
        try
        {
            var ClientyData = context.Clienties
                                    .Where(q => q.Fname == namevar.Text)
                                    .ToList();

            ListData.ItemsSource = ClientyData;
        }
        catch
        {
            MainWindow frm = new MainWindow();
            frm.Show();
            this.Hide();
        }
    }

    public void Btnord(Object Sender, RoutedEventArgs e)
    {
        
        try
        {
            var ClientyData = context.Clienties
                                    .OrderBy(w => w.Fname)
                                    .ToList();

            ListData.ItemsSource = ClientyData;
        }
        catch
        {
            MainWindow frm = new MainWindow();
            frm.Show();
            this.Hide();
        }
    }
}