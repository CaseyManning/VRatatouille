using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using UnityEngine.Experimental.Animations;

public class ArmIK : MonoBehaviour
{
    public Transform endJoint_L;
    public Transform endJoint_R;

    Transform m_TopJoint_R;
    Transform m_MidJoint_R;
    GameObject m_Effector_R;

    Transform m_TopJoint_L;
    Transform m_MidJoint_L;
    GameObject m_Effector_L;

    public PlayableGraph m_Graph;
    AnimationScriptPlayable m_IKPlayable;

    public AnimationClip idleClip;
    public GameObject effector_L;
    public GameObject effector_R;

    public Vector3 startPos_L;
    public Vector3 startPos_R;

    void OnEnable()
    {
        if (idleClip == null)
            return;

        if (endJoint_L == null)
            return;

        m_MidJoint_L = endJoint_L.parent;
        if (m_MidJoint_L == null)
            return;

        m_TopJoint_L = m_MidJoint_L.parent;
        if (m_TopJoint_L == null)
            return;

        m_MidJoint_R = endJoint_R.parent;
        if (m_MidJoint_R == null)
            return;

        m_TopJoint_R = m_MidJoint_R.parent;
        if (m_TopJoint_R == null)
            return;

        m_Graph = PlayableGraph.Create("new");// GetComponent<Animator>().playableGraph;

        m_Graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        var output = AnimationPlayableOutput.Create(m_Graph, "ouput", GetComponent<Animator>());

        var twoBoneIKJob = new TwoBoneIKJob();
        twoBoneIKJob.Setup(GetComponent<Animator>(), m_TopJoint_L, m_MidJoint_L, endJoint_L, effector_L.transform, m_TopJoint_R, m_MidJoint_R, endJoint_R, effector_R.transform);

        m_IKPlayable = AnimationScriptPlayable.Create(m_Graph, twoBoneIKJob);
        m_IKPlayable.AddInput(AnimationClipPlayable.Create(m_Graph, idleClip), 0, 1.0f);

        output.SetSourcePlayable(m_IKPlayable);

    }

    private void Start()
    {
        startPos_L = effector_L.transform.localPosition;
        startPos_R = effector_R.transform.localPosition;
    }

    void OnDisable()
    {
        m_Graph.Destroy();
        //Object.Destroy(m_Effector_L);
        //Object.Destroy(m_Effector_R);
    }

    public void resetAnchors()
    {
        effector_L.transform.localPosition = startPos_L;
        effector_R.transform.localPosition = startPos_R;
    }
}
