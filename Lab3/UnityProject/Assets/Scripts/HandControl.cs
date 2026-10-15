
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControl : MonoBehaviour
{
    public Key tecla = Key.F;
    public InputActionReference grip;

    private Animator animator;
    private int stateHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        stateHash = Animator.StringToHash("Base Layer.Armature|ArmatureAction");

        if (grip != null)
            grip.action.Enable();

        animator.Play(stateHash, 0, 0f);
        animator.Update(0f);
        animator.speed = 0f;
    }

    void Update()
    {
        bool teclado = Keyboard.current != null &&
                       Keyboard.current[tecla].isPressed;

        bool mando = grip != null &&
                     grip.action != null &&
                     grip.action.IsPressed();

        float posicion = (teclado || mando) ? 1f : 0f;

        animator.Play(stateHash, 0, posicion);
        animator.Update(0f);
    }
}
