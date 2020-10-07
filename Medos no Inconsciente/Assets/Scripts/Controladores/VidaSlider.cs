using UnityEngine;
using UnityEngine.UI;

public class VidaSlider : MonoBehaviour
{
    public Slider slider;
    public Gradient gradiente;
    public Image barra;

    public void MaxVida(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;

        barra.color = gradiente.Evaluate(1f);
    }

    public void EscolherVida(int vida)
    {
        slider.value = vida;
        barra.color = gradiente.Evaluate(slider.normalizedValue);
    }
}
