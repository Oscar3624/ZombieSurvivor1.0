using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour, IArma
{
    [SerializeField] private GameObject projectilePrefab; // Prefab del proyectil.
    [SerializeField] private Transform firePoint;        // Punto desde el cual se dispara.
    [SerializeField] private float projectileSpeed = 10f;

    public void PlayerShoot(Vector3 direction)
    {
        Debug.Log("Disparo");

        if (projectilePrefab != null && firePoint != null)
        {
            // Instanciar el proyectil.
            GameObject projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Obtener el componente de proyectil y lanzarlo.
            IProyectil projectile = projectileInstance.GetComponent<IProyectil>();
            if (projectile != null)
            {
                //Vector2 direction = firePoint.right; // Asumiendo que el arma apunta hacia la derecha.
                projectile.Launch(direction, projectileSpeed);
            }
        }
    }
}
