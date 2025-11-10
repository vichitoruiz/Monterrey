using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;

namespace SSEL.MONTERREY.WPF.ViewModels;

public class EstadisticasVM
{
    public ObservableCollection<ISeries> PieSeries { get; set; }

    public EstadisticasVM()
    {
        PieSeries = new ObservableCollection<ISeries>
        {
            new PieSeries<double> { Name = "Usuarios al día", Values = new double[]{85} },
            new PieSeries<double> { Name = "Morosos", Values = new double[]{15} }
        };
    }
}
