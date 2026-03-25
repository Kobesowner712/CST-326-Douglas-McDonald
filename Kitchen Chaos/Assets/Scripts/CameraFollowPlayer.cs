using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    [SerializeField] private Player player;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.gameObject.transform.position.x,
            gameObject.transform.position.y, player.gameObject.transform.position.z);

    }
}
