// using System.Collections.Generic;
// using UnityEngine;
// /// <summary>
// /// 状态基类
// /// </summary>
// /// <typeparam name="T">状态持有者类型</typeparam>
// public class FsmState<T> where T : class
// {
//     /// <summary>
//     /// 状态机事件的响应方法模板
//     /// </summary>
//     public delegate void FsmEventHandler<T>(Fsm<T> fsm, object sender, object userData) where T : class;

//     /// <summary>
//     /// 状态订阅的事件字典
//     /// </summary>
//     private Dictionary<int, FsmEventHandler<T>> m_EventHandlers;

//     public FsmState()
//     {
//         m_EventHandlers = new Dictionary<int, FsmEventHandler<T>>();
//     }
//     /// <summary>
//     /// 订阅状态机事件。
//     /// </summary>
//     protected void SubscribeEvent(int eventId, FsmEventHandler<T> eventHandler)
//     {
//         if (eventHandler == null)
//         {
//             Debug.LogError("状态机事件响应方法为空，无法订阅状态机事件");
//         }

//         if (!m_EventHandlers.ContainsKey(eventId))
//         {
//             m_EventHandlers[eventId] = eventHandler;
//         }
//         else
//         {
//             m_EventHandlers[eventId] += eventHandler;
//         }
//     }

//     /// <summary>
//     /// 取消订阅状态机事件。
//     /// </summary>
//     protected void UnsubscribeEvent(int eventId, FsmEventHandler<T> eventHandler)
//     {
//         if (eventHandler == null)
//         {
//             Debug.LogError("状态机事件响应方法为空，无法取消订阅状态机事件");
//         }

//         if (m_EventHandlers.ContainsKey(eventId))
//         {
//             m_EventHandlers[eventId] -= eventHandler;
//         }
//     }

//     /// <summary>
//     /// 响应状态机事件。
//     /// </summary>
//     public void OnEvent(Fsm<T> fsm, object sender, int eventId, object userData)
//     {
//         FsmEventHandler<T> eventHandlers = null;
//         if (m_EventHandlers.TryGetValue(eventId, out eventHandlers))
//         {
//             if (eventHandlers != null)
//             {
//                 eventHandlers(fsm, sender, userData);
//             }
//         }
//     }    /// <summary>
//          /// 状态机状态初始化时调用
//          /// </summary>
//          /// <param name="fsm">状态机引用</param>
//     public virtual void OnInit(Fsm<T> fsm)
//     {

//     }

//     /// <summary>
//     /// 状态机状态进入时调用
//     /// </summary>
//     /// <param name="fsm">状态机引用</param>
//     public virtual void OnEnter(Fsm<T> fsm)
//     {

//     }

//     /// <summary>
//     /// 状态机状态轮询时调用
//     /// </summary>
//     /// <param name="fsm">状态机引用</param>
//     public virtual void OnUpdate(Fsm<T> fsm, float elapseSeconds, float realElapseSeconds)
//     {

//     }

//     /// <summary>
//     /// 状态机状态离开时调用。
//     /// </summary>
//     /// <param name="fsm">状态机引用。</param>
//     /// <param name="isShutdown">是关闭状态机时触发</param>
//     public virtual void OnLeave(Fsm<T> fsm, bool isShutdown)
//     {

//     }

//     /// <summary>
//     /// 状态机状态销毁时调用
//     /// </summary>
//     /// <param name="fsm">状态机引用。</param>
//     public virtual void OnDestroy(Fsm<T> fsm)
//     {
//         m_EventHandlers.Clear();
//     }
// }