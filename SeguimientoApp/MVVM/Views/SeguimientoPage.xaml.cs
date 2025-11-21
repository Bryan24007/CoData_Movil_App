namespace SeguimientoApp.MVVM.Views;
using SeguimientoApp.MVVM.Models;
using SeguimientoApp.MVVM.ViewModels;


public partial class SeguimientoPage : ContentPage
{
    private Frame _currentExpandedFrame = null;
    private VerticalStackLayout _currentExpandedPanel = null;

    public SeguimientoPage()
    {
        InitializeComponent();
    }

    private async void OnReporteTapped(object sender, TappedEventArgs e)
    {
        if (sender is not Frame tappedFrame)
            return;

        var tappedPanel = FindDetallesPanel(tappedFrame);

        // Si hay un panel expandido y es diferente al actual, lo cerramos
        if (_currentExpandedPanel != null && _currentExpandedPanel != tappedPanel)
        {
            await _currentExpandedPanel.FadeTo(0, 150);
            _currentExpandedPanel.IsVisible = false;
        }

        // Toggle del panel actual
        if (tappedPanel != null)
        {
            if (tappedPanel.IsVisible)
            {
                // Cerrar
                await tappedPanel.FadeTo(0, 150);
                tappedPanel.IsVisible = false;
                _currentExpandedPanel = null;
                _currentExpandedFrame = null;
            }
            else
            {
                // Abrir
                tappedPanel.IsVisible = true;
                tappedPanel.Opacity = 0;
                await tappedPanel.FadeTo(1, 200);
                _currentExpandedPanel = tappedPanel;
                _currentExpandedFrame = tappedFrame;
            }
        }
    }

    private VerticalStackLayout FindDetallesPanel(Element parent)
    {
        if (parent == null)
            return null;

        // Búsqueda recursiva del panel de detalles
        foreach (var element in GetAllDescendants(parent))
        {
            if (element is VerticalStackLayout vsl)
            {
                // Identificar el panel de detalles por su primer hijo (BoxView separador)
                if (vsl.Children.Count > 0 &&
                    vsl.Children[0] is BoxView bv &&
                    bv.HeightRequest == 1)
                {
                    return vsl;
                }
            }
        }
        return null;
    }

    private IEnumerable<Element> GetAllDescendants(Element parent)
    {
        var children = new List<Element>();

        if (parent is Layout layout)
        {
            foreach (var child in layout.Children)
            {
                if (child is Element el)
                {
                    children.Add(el);
                    children.AddRange(GetAllDescendants(el));
                }
            }
        }
        else if (parent is ContentView cv && cv.Content is Element content)
        {
            children.Add(content);
            children.AddRange(GetAllDescendants(content));
        }
        else if (parent is Frame frame && frame.Content is Element frameContent)
        {
            children.Add(frameContent);
            children.AddRange(GetAllDescendants(frameContent));
        }
        else if (parent is Border border && border.Content is Element borderContent)
        {
            children.Add(borderContent);
            children.AddRange(GetAllDescendants(borderContent));
        }

        return children;
    }
}