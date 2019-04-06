// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerControls : InputActionAssetReference
{
    public PlayerControls()
    {
    }
    public PlayerControls(InputActionAsset asset)
        : base(asset)
    {
    }
    [NonSerialized] private bool m_Initialized;
    private void Initialize()
    {
        // Cube
        m_Cube = asset.GetActionMap("Cube");
        m_Cube_Move = m_Cube.GetAction("Move");
        m_Cube_Reset = m_Cube.GetAction("Reset");
        m_Cube_LoadSecretLevel = m_Cube.GetAction("LoadSecretLevel");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        if (m_CubeActionsCallbackInterface != null)
        {
            Cube.SetCallbacks(null);
        }
        m_Cube = null;
        m_Cube_Move = null;
        m_Cube_Reset = null;
        m_Cube_LoadSecretLevel = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        var CubeCallbacks = m_CubeActionsCallbackInterface;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
        Cube.SetCallbacks(CubeCallbacks);
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Cube
    private InputActionMap m_Cube;
    private ICubeActions m_CubeActionsCallbackInterface;
    private InputAction m_Cube_Move;
    private InputAction m_Cube_Reset;
    private InputAction m_Cube_LoadSecretLevel;
    public struct CubeActions
    {
        private PlayerControls m_Wrapper;
        public CubeActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Cube_Move; } }
        public InputAction @Reset { get { return m_Wrapper.m_Cube_Reset; } }
        public InputAction @LoadSecretLevel { get { return m_Wrapper.m_Cube_LoadSecretLevel; } }
        public InputActionMap Get() { return m_Wrapper.m_Cube; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(CubeActions set) { return set.Get(); }
        public void SetCallbacks(ICubeActions instance)
        {
            if (m_Wrapper.m_CubeActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_CubeActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_CubeActionsCallbackInterface.OnMove;
                Move.cancelled -= m_Wrapper.m_CubeActionsCallbackInterface.OnMove;
                Reset.started -= m_Wrapper.m_CubeActionsCallbackInterface.OnReset;
                Reset.performed -= m_Wrapper.m_CubeActionsCallbackInterface.OnReset;
                Reset.cancelled -= m_Wrapper.m_CubeActionsCallbackInterface.OnReset;
                LoadSecretLevel.started -= m_Wrapper.m_CubeActionsCallbackInterface.OnLoadSecretLevel;
                LoadSecretLevel.performed -= m_Wrapper.m_CubeActionsCallbackInterface.OnLoadSecretLevel;
                LoadSecretLevel.cancelled -= m_Wrapper.m_CubeActionsCallbackInterface.OnLoadSecretLevel;
            }
            m_Wrapper.m_CubeActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.cancelled += instance.OnMove;
                Reset.started += instance.OnReset;
                Reset.performed += instance.OnReset;
                Reset.cancelled += instance.OnReset;
                LoadSecretLevel.started += instance.OnLoadSecretLevel;
                LoadSecretLevel.performed += instance.OnLoadSecretLevel;
                LoadSecretLevel.cancelled += instance.OnLoadSecretLevel;
            }
        }
    }
    public CubeActions @Cube
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new CubeActions(this);
        }
    }
}
public interface ICubeActions
{
    void OnMove(InputAction.CallbackContext context);
    void OnReset(InputAction.CallbackContext context);
    void OnLoadSecretLevel(InputAction.CallbackContext context);
}
