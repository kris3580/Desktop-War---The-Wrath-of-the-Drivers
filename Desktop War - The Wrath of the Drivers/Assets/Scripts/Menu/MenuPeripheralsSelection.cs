using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPeripheralsSelection : MonoBehaviour
{

    public static PeripheralType selectedPeripheral;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        animator.SetBool("isHovered", true); 
    }

    void OnMouseExit()
    {
        animator.SetBool("isHovered", false);
    }

    private void OnMouseUp()
    {
        
    }

    private void HoverPeripheralHandler()
    {

    }

    private void ExitHoverPeripheralHandler()
    {

    }

    private void ClickedPeripheralHandler()
    {

    }


}
