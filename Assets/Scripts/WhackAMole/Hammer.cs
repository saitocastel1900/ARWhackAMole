using UI;
using UnityEngine;

namespace WhackAMole
{
    public class Hammer : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Mole"))
                    {
                        hit.transform.gameObject.GetComponent<MoleMover>().Hit();

                        GameObject.Find("Canvas").GetComponent<MainUI>().AddScore();
                    }
                }
            }
        }
    }
}