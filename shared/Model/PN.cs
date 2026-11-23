using System.Data;
using Microsoft.VisualBasic;

namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen) {
	    // Tilføjet mulighed for at vælge start og slut dato for pn
        ArgumentNullException.ThrowIfNull(givesDen);

        DateTime dato = givesDen.dato.Date;

        if (dato < startDen.Date || dato >= slutDen.Date)
        {
	        return false;
        }
        dates.Add(new Dato{ dato = dato});
        return true;
    }

    public override double doegnDosis() {
	    //finder gennemsnittet af døgndosis for pn per dag  - formel: antalgivninger*enheder/dage fra start til slut
	    if (dates.Count == 0)
	    {
		    return 0;
	    }

	    DateTime førsteDato = dates.Min(d => d.dato.Date);
	    DateTime sidsteDato = dates.Max(d => d.dato.Date);
	    int antalDage = (sidsteDato - førsteDato).Days + 1;

	    return samletDosis() / antalDage;
    }


    public override double samletDosis() {
        return dates.Count() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
