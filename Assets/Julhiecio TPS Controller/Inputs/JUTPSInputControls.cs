using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace JUTPS.JUInputSystem
{
    public partial class JUTPSInputControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }

        public JUTPSInputControls(InputActionAsset reference)
        {
            asset = reference;
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
            m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
            m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
            m_Player_Punch = m_Player.FindAction("Punch", throwIfNotFound: true);
            m_Player_Roll = m_Player.FindAction("Roll", throwIfNotFound: true);
            m_Player_Prone = m_Player.FindAction("Prone", throwIfNotFound: true);
            m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
            m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_Pickup = m_Player.FindAction("Pickup", throwIfNotFound: true);
            m_Player_OpenInventory = m_Player.FindAction("Open Inventory", throwIfNotFound: true);
            m_Player_Next = m_Player.FindAction("Next", throwIfNotFound: true);
            m_Player_Previous = m_Player.FindAction("Previous", throwIfNotFound: true);
            m_Player_MousePosition = m_Player.FindAction("Mouse Position", throwIfNotFound: true);
            m_Player_Slot1 = m_Player.FindAction("Slot1", throwIfNotFound: true);
            m_Player_Slot2 = m_Player.FindAction("Slot2", throwIfNotFound: true);
            m_Player_Slot3 = m_Player.FindAction("Slot3", throwIfNotFound: true);
            m_Player_Slot4 = m_Player.FindAction("Slot4", throwIfNotFound: true);
            m_Player_Slot5 = m_Player.FindAction("Slot5", throwIfNotFound: true);
            m_Player_Slot6 = m_Player.FindAction("Slot6", throwIfNotFound: true);
            m_Player_Slot7 = m_Player.FindAction("Slot7", throwIfNotFound: true);
            m_Player_Slot8 = m_Player.FindAction("Slot8", throwIfNotFound: true);
            m_Player_Slot9 = m_Player.FindAction("Slot9", throwIfNotFound: true);
            m_Player_Slot10 = m_Player.FindAction("Slot10", throwIfNotFound: true);
            m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
            m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
            m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
            m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
            m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
            m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
            m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
            m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
            m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
            m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Fire;
        private readonly InputAction m_Player_Aim;
        private readonly InputAction m_Player_Run;
        private readonly InputAction m_Player_Punch;
        private readonly InputAction m_Player_Roll;
        private readonly InputAction m_Player_Prone;
        private readonly InputAction m_Player_Crouch;
        private readonly InputAction m_Player_Reload;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_Pickup;
        private readonly InputAction m_Player_OpenInventory;
        private readonly InputAction m_Player_Next;
        private readonly InputAction m_Player_Previous;
        private readonly InputAction m_Player_MousePosition;
        private readonly InputAction m_Player_Slot1;
        private readonly InputAction m_Player_Slot2;
        private readonly InputAction m_Player_Slot3;
        private readonly InputAction m_Player_Slot4;
        private readonly InputAction m_Player_Slot5;
        private readonly InputAction m_Player_Slot6;
        private readonly InputAction m_Player_Slot7;
        private readonly InputAction m_Player_Slot8;
        private readonly InputAction m_Player_Slot9;
        private readonly InputAction m_Player_Slot10;
        private readonly InputAction m_Player_Dash;

        public struct PlayerActions
        {
            private JUTPSInputControls m_Wrapper;

            public PlayerActions(JUTPSInputControls wrapper) { m_Wrapper = wrapper; }

            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Fire => m_Wrapper.m_Player_Fire;
            public InputAction @Aim => m_Wrapper.m_Player_Aim;
            public InputAction @Run => m_Wrapper.m_Player_Run;
            public InputAction @Punch => m_Wrapper.m_Player_Punch;
            public InputAction @Roll => m_Wrapper.m_Player_Roll;
            public InputAction @Prone => m_Wrapper.m_Player_Prone;
            public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
            public InputAction @Reload => m_Wrapper.m_Player_Reload;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @Pickup => m_Wrapper.m_Player_Pickup;
            public InputAction @OpenInventory => m_Wrapper.m_Player_OpenInventory;
            public InputAction @Next => m_Wrapper.m_Player_Next;
            public InputAction @Previous => m_Wrapper.m_Player_Previous;
            public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
            public InputAction @Slot1 => m_Wrapper.m_Player_Slot1;
            public InputAction @Slot2 => m_Wrapper.m_Player_Slot2;
            public InputAction @Slot3 => m_Wrapper.m_Player_Slot3;
            public InputAction @Slot4 => m_Wrapper.m_Player_Slot4;
            public InputAction @Slot5 => m_Wrapper.m_Player_Slot5;
            public InputAction @Slot6 => m_Wrapper.m_Player_Slot6;
            public InputAction @Slot7 => m_Wrapper.m_Player_Slot7;
            public InputAction @Slot8 => m_Wrapper.m_Player_Slot8;
            public InputAction @Slot9 => m_Wrapper.m_Player_Slot9;
            public InputAction @Slot10 => m_Wrapper.m_Player_Slot10;
            public InputAction @Dash => m_Wrapper.m_Player_Dash;

            public InputActionMap Get() { return m_Wrapper.m_Player; }

            public void Enable() { Get().Enable(); }

            public void Disable() { Get().Disable(); }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }

            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Prone.started += instance.OnProne;
                @Prone.performed += instance.OnProne;
                @Prone.canceled += instance.OnProne;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
                @OpenInventory.started += instance.OnOpenInventory;
                @OpenInventory.performed += instance.OnOpenInventory;
                @OpenInventory.canceled += instance.OnOpenInventory;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Slot1.started += instance.OnSlot1;
                @Slot1.performed += instance.OnSlot1;
                @Slot1.canceled += instance.OnSlot1;
                @Slot2.started += instance.OnSlot2;
                @Slot2.performed += instance.OnSlot2;
                @Slot2.canceled += instance.OnSlot2;
                @Slot3.started += instance.OnSlot3;
                @Slot3.performed += instance.OnSlot3;
                @Slot3.canceled += instance.OnSlot3;
                @Slot4.started += instance.OnSlot4;
                @Slot4.performed += instance.OnSlot4;
                @Slot4.canceled += instance.OnSlot4;
                @Slot5.started += instance.OnSlot5;
                @Slot5.performed += instance.OnSlot5;
                @Slot5.canceled += instance.OnSlot5;
                @Slot6.started += instance.OnSlot6;
                @Slot6.performed += instance.OnSlot6;
                @Slot6.canceled += instance.OnSlot6;
                @Slot7.started += instance.OnSlot7;
                @Slot7.performed += instance.OnSlot7;
                @Slot7.canceled += instance.OnSlot7;
                @Slot8.started += instance.OnSlot8;
                @Slot8.performed += instance.OnSlot8;
                @Slot8.canceled += instance.OnSlot8;
                @Slot9.started += instance.OnSlot9;
                @Slot9.performed += instance.OnSlot9;
                @Slot9.canceled += instance.OnSlot9;
                @Slot10.started += instance.OnSlot10;
                @Slot10.performed += instance.OnSlot10;
                @Slot10.canceled += instance.OnSlot10;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Fire.started -= instance.OnFire;
                @Fire.performed -= instance.OnFire;
                @Fire.canceled -= instance.OnFire;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @Punch.started -= instance.OnPunch;
                @Punch.performed -= instance.OnPunch;
                @Punch.canceled -= instance.OnPunch;
                @Roll.started -= instance.OnRoll;
                @Roll.performed -= instance.OnRoll;
                @Roll.canceled -= instance.OnRoll;
                @Prone.started -= instance.OnProne;
                @Prone.performed -= instance.OnProne;
                @Prone.canceled -= instance.OnProne;
                @Crouch.started -= instance.OnCrouch;
                @Crouch.performed -= instance.OnCrouch;
                @Crouch.canceled -= instance.OnCrouch;
                @Reload.started -= instance.OnReload;
                @Reload.performed -= instance.OnReload;
                @Reload.canceled -= instance.OnReload;
                @Interact.started -= instance.OnInteract;
                @Interact.performed -= instance.OnInteract;
                @Interact.canceled -= instance.OnInteract;
                @Pickup.started -= instance.OnPickup;
                @Pickup.performed -= instance.OnPickup;
                @Pickup.canceled -= instance.OnPickup;
                @OpenInventory.started -= instance.OnOpenInventory;
                @OpenInventory.performed -= instance.OnOpenInventory;
                @OpenInventory.canceled -= instance.OnOpenInventory;
                @Next.started -= instance.OnNext;
                @Next.performed -= instance.OnNext;
                @Next.canceled -= instance.OnNext;
                @Previous.started -= instance.OnPrevious;
                @Previous.performed -= instance.OnPrevious;
                @Previous.canceled -= instance.OnPrevious;
                @MousePosition.started -= instance.OnMousePosition;
                @MousePosition.performed -= instance.OnMousePosition;
                @MousePosition.canceled -= instance.OnMousePosition;
                @Slot1.started -= instance.OnSlot1;
                @Slot1.performed -= instance.OnSlot1;
                @Slot1.canceled -= instance.OnSlot1;
                @Slot2.started -= instance.OnSlot2;
                @Slot2.performed -= instance.OnSlot2;
                @Slot2.canceled -= instance.OnSlot2;
                @Slot3.started -= instance.OnSlot3;
                @Slot3.performed -= instance.OnSlot3;
                @Slot3.canceled -= instance.OnSlot3;
                @Slot4.started -= instance.OnSlot4;
                @Slot4.performed -= instance.OnSlot4;
                @Slot4.canceled -= instance.OnSlot4;
                @Slot5.started -= instance.OnSlot5;
                @Slot5.performed -= instance.OnSlot5;
                @Slot5.canceled -= instance.OnSlot5;
                @Slot6.started -= instance.OnSlot6;
                @Slot6.performed -= instance.OnSlot6;
                @Slot6.canceled -= instance.OnSlot6;
                @Slot7.started -= instance.OnSlot7;
                @Slot7.performed -= instance.OnSlot7;
                @Slot7.canceled -= instance.OnSlot7;
                @Slot8.started -= instance.OnSlot8;
                @Slot8.performed -= instance.OnSlot8;
                @Slot8.canceled -= instance.OnSlot8;
                @Slot9.started -= instance.OnSlot9;
                @Slot9.performed -= instance.OnSlot9;
                @Slot9.canceled -= instance.OnSlot9;
                @Slot10.started -= instance.OnSlot10;
                @Slot10.performed -= instance.OnSlot10;
                @Slot10.canceled -= instance.OnSlot10;
                @Dash.started -= instance.OnDash;
                @Dash.performed -= instance.OnDash;
                @Dash.canceled -= instance.OnDash;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public PlayerActions @Player => new PlayerActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
        private readonly InputAction m_UI_Navigate;
        private readonly InputAction m_UI_Submit;
        private readonly InputAction m_UI_Cancel;
        private readonly InputAction m_UI_Point;
        private readonly InputAction m_UI_Click;
        private readonly InputAction m_UI_ScrollWheel;
        private readonly InputAction m_UI_MiddleClick;
        private readonly InputAction m_UI_RightClick;
        private readonly InputAction m_UI_TrackedDevicePosition;
        private readonly InputAction m_UI_TrackedDeviceOrientation;

        public struct UIActions
        {
            private JUTPSInputControls m_Wrapper;

            public UIActions(JUTPSInputControls wrapper) { m_Wrapper = wrapper; }

            public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
            public InputAction @Submit => m_Wrapper.m_UI_Submit;
            public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
            public InputAction @Point => m_Wrapper.m_UI_Point;
            public InputAction @Click => m_Wrapper.m_UI_Click;
            public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
            public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
            public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
            public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
            public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;

            public InputActionMap Get() { return m_Wrapper.m_UI; }

            public void Enable() { Get().Enable(); }

            public void Disable() { Get().Disable(); }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }

            public void AddCallbacks(IUIActions instance)
            {
                if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }

            private void UnregisterCallbacks(IUIActions instance)
            {
                @Navigate.started -= instance.OnNavigate;
                @Navigate.performed -= instance.OnNavigate;
                @Navigate.canceled -= instance.OnNavigate;
                @Submit.started -= instance.OnSubmit;
                @Submit.performed -= instance.OnSubmit;
                @Submit.canceled -= instance.OnSubmit;
                @Cancel.started -= instance.OnCancel;
                @Cancel.performed -= instance.OnCancel;
                @Cancel.canceled -= instance.OnCancel;
                @Point.started -= instance.OnPoint;
                @Point.performed -= instance.OnPoint;
                @Point.canceled -= instance.OnPoint;
                @Click.started -= instance.OnClick;
                @Click.performed -= instance.OnClick;
                @Click.canceled -= instance.OnClick;
                @ScrollWheel.started -= instance.OnScrollWheel;
                @ScrollWheel.performed -= instance.OnScrollWheel;
                @ScrollWheel.canceled -= instance.OnScrollWheel;
                @MiddleClick.started -= instance.OnMiddleClick;
                @MiddleClick.performed -= instance.OnMiddleClick;
                @MiddleClick.canceled -= instance.OnMiddleClick;
                @RightClick.started -= instance.OnRightClick;
                @RightClick.performed -= instance.OnRightClick;
                @RightClick.canceled -= instance.OnRightClick;
                @TrackedDevicePosition.started -= instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= instance.OnTrackedDeviceOrientation;
            }

            public void RemoveCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IUIActions instance)
            {
                foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }

        public UIActions @UI => new UIActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;

        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }

        private int m_GamepadSchemeIndex = -1;

        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }

        private int m_TouchSchemeIndex = -1;

        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }

        private int m_JoystickSchemeIndex = -1;

        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }

        private int m_XRSchemeIndex = -1;

        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }

        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);

            void OnLook(InputAction.CallbackContext context);

            void OnJump(InputAction.CallbackContext context);

            void OnFire(InputAction.CallbackContext context);

            void OnAim(InputAction.CallbackContext context);

            void OnRun(InputAction.CallbackContext context);

            void OnPunch(InputAction.CallbackContext context);

            void OnRoll(InputAction.CallbackContext context);

            void OnProne(InputAction.CallbackContext context);

            void OnCrouch(InputAction.CallbackContext context);

            void OnReload(InputAction.CallbackContext context);

            void OnInteract(InputAction.CallbackContext context);

            void OnPickup(InputAction.CallbackContext context);

            void OnOpenInventory(InputAction.CallbackContext context);

            void OnNext(InputAction.CallbackContext context);

            void OnPrevious(InputAction.CallbackContext context);

            void OnMousePosition(InputAction.CallbackContext context);

            void OnSlot1(InputAction.CallbackContext context);

            void OnSlot2(InputAction.CallbackContext context);

            void OnSlot3(InputAction.CallbackContext context);

            void OnSlot4(InputAction.CallbackContext context);

            void OnSlot5(InputAction.CallbackContext context);

            void OnSlot6(InputAction.CallbackContext context);

            void OnSlot7(InputAction.CallbackContext context);

            void OnSlot8(InputAction.CallbackContext context);

            void OnSlot9(InputAction.CallbackContext context);

            void OnSlot10(InputAction.CallbackContext context);

            void OnDash(InputAction.CallbackContext context);
        }

        public interface IUIActions
        {
            void OnNavigate(InputAction.CallbackContext context);

            void OnSubmit(InputAction.CallbackContext context);

            void OnCancel(InputAction.CallbackContext context);

            void OnPoint(InputAction.CallbackContext context);

            void OnClick(InputAction.CallbackContext context);

            void OnScrollWheel(InputAction.CallbackContext context);

            void OnMiddleClick(InputAction.CallbackContext context);

            void OnRightClick(InputAction.CallbackContext context);

            void OnTrackedDevicePosition(InputAction.CallbackContext context);

            void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        }
    }
}