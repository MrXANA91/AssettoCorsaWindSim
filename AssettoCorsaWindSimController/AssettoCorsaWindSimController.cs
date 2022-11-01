using System.Timers;
using Timer = System.Timers.Timer;

namespace AssettoCorsaWindSim;

public class AssettoCorsaWindSimController
{
    public static int NUMBER_OF_AVAILABLE_VENTILATORS = 2;  // prévoir de récupérer l'info depuis l'arduino

    private ArduinoSerialCom com;

    public AssettoCorsaWindSimController() {
        com = new ArduinoSerialCom();

        // Objets representants les ventilateurs, avec les paramètres softs pour le calcul (angle, maxSpeed, gamma)
        // ainsi que leurs attributs ENABLE et POWER du hardware
    }

    public void Start() {

    }

    public void Stop() {

    }
}