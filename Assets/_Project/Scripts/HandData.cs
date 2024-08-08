using UnityEngine;

public class HandData : MonoBehaviour
{
   public enum HandModelType {Left, Right}

   public HandModelType HandType;
   public Transform root;
   public Animator animator;
   public Transform[] fingerBones;
}
