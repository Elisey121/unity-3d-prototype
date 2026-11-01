using UnityEngine;

public class BonusTrigger : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("ОШИБКА: На этом объекте нет компонента Animator! Проверьте, куда вы повесили скрипт.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Кто-то вошел в зону куба: " + other.gameObject.name + " с тегом: " + other.tag);

        if (other.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetBool("IsNear", true);
                Debug.Log("СИГНАЛ ОТПРАВЛЕН: Игрок обнаружен, включаем IsNear = true!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetBool("IsNear", false);
                Debug.Log("СИГНАЛ ОТПРАВЛЕН: Игрок ушел, выключаем IsNear = false!");
            }
        }
    }
}