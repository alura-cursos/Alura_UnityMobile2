using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDaReservaDeInimigos : MonoBehaviour {

    private ReservaDeInimigos minhaReserva;

    public void Devolver()
    {
        this.minhaReserva.DevolverInimigo(this.gameObject);
    }

    public void SetReserva(ReservaDeInimigos reserva)
    {
        this.minhaReserva = reserva;
    }
}
