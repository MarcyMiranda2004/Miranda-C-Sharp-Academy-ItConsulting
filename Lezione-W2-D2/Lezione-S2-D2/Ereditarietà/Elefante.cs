using System.Diagnostics.Tracing;
using GestioneAnimale;

namespace GestioneElefante;

public class Elefante : Animale
{
    public void ImpostaEta(int nuovaEta)
    {
        eta = nuovaEta;
    }
}