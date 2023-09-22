// using System;
// using System.Collections.Generic;
// using UnityEngine;

// /// <summary>
// /// 状态机接口
// /// </summary>
// public interface IFsm
// {
//     /// <summary>
//     /// 状态机名字
//     /// </summary>
//     string Name { get; }

//     /// <summary>
//     /// 状态机持有者类型
//     /// </summary>
//     Type OwnerType { get; }

//     /// <summary>
//     /// 状态机是否被销毁
//     /// </summary>
//     bool IsDestroyed { get; }

//     /// <summary>
//     /// 当前状态运行时间
//     /// </summary>
//     float CurrentStateTime { get; }

//     /// <summary>
//     /// 状态机轮询
//     /// </summary>
//     void Update(float elapseSeconds, float realElapseSeconds);

//     /// <summary>
//     /// 关闭并清理状态机。
//     /// </summary>
//     void Shutdown();

// }

// /// <summary>
// /// 状态机
// /// </summary>
// /// <typeparam name="T">状态机持有者类型</typeparam>
// public class Fsm<T> : IFsm where T : class
// {

//     public Fsm(string name, T owner, params FsmState<T>[] states)
//     {
//         if (owner == null)
//         {
//             Debug.LogError("状态机持有者为空");
//         }

//         if (states == null || states.Length < 1)
//         {
//             Debug.LogError("没有要添加进状态机的状态");
//         }

//         Name = name;
//         Owner = owner;
//         m_States = new Dictionary<string, FsmState<T>>();
//         m_Datas = new Dictionary<string, object>();

//         foreach (FsmState<T> state in states)
//         {
//             if (state == null)
//             {
//                 Debug.LogError("要添加进状态机的状态为空");
//             }

//             string stateName = state.GetType().FullName;
//             if (m_States.ContainsKey(stateName))
//             {
//                 Debug.LogError("要添加进状态机的状态已存在：" + stateName);
//             }

//             m_States.Add(stateName, state);
//             state.OnInit(this);
//         }

//         CurrentStateTime = 0f;
//         CurrentState = null;
//         IsDestroyed = false;

//     }

//     /// <summary>
//     /// 状态机名字
//     /// </summary>
//     public string Name { get; private set; }

//     /// <summary>
//     /// 获取状态机持有者类型
//     /// </summary>
//     public Type OwnerType
//     {
//         get
//         {
//             return typeof(T);
//         }
//     }

//     /// <summary>
//     /// 状态机是否被销毁
//     /// </summary>
//     public bool IsDestroyed { get; private set; }

//     /// <summary>
//     /// 当前状态运行时间
//     /// </summary>
//     public float CurrentStateTime { get; private set; }

//     /// <summary>
//     /// 状态机里所有状态的字典
//     /// </summary>
//     private Dictionary<string, FsmState<T>> m_States;

//     /// <summary>
//     /// 状态机里所有数据的字典
//     /// </summary>
//     private Dictionary<string, object> m_Datas;

//     /// <summary>
//     /// 当前状态
//     /// </summary>
//     public FsmState<T> CurrentState { get; private set; }

//     /// <summary>
//     /// 状态机持有者
//     /// </summary>
//     public T Owner { get; private set; }

//     /// <summary>
//     /// 关闭并清理状态机。
//     /// </summary>
//     public void Shutdown()
//     {
//         if (CurrentState != null)
//         {
//             CurrentState.OnLeave(this, true);
//             CurrentState = null;
//             CurrentStateTime = 0f;
//         }

//         foreach (KeyValuePair<string, FsmState<T>> state in m_States)
//         {
//             state.Value.OnDestroy(this);
//         }

//         m_States.Clear();
//         m_Datas.Clear();

//         IsDestroyed = true;
//     }

//     /// <summary>
//     /// 状态机轮询
//     /// </summary>
//     public void Update(float elapseSeconds, float realElapseSeconds)
//     {
//         if (CurrentState == null)
//         {
//             return;
//         }

//         CurrentStateTime += elapseSeconds;
//         CurrentState.OnUpdate(this, elapseSeconds, realElapseSeconds);
//     }

// }