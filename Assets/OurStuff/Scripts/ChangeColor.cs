using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public MeshRenderer mRen;
    public List<Material> mColors = new List<Material>();
    int position = 0;
    public int goal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonPress()
    {
        this.TryGetComponent(out I_Puzzle puzzle);
        position++;
        if (position == mColors.Count)
            position = 0;
        mRen.material = mColors[position];
        
        if (position == goal) 
        {
            Debug.Log("whoo");
            puzzle.done(true);
        }
        else
        {
            puzzle.done(false);

        }
    }


}