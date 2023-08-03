using System.Collections.Generic;
using System;
using UnityEngine;

namespace LynxGlobalEventTool
{
    /// <summary>
    /// 大破坏事件系统
    /// </summary>
    public class LynxEvents :MonoBehaviour
    {
        static LynxEvents Instance;
        public LynxEvents() 
        {
            Instance = new LynxEvents();
        }

        static Dictionary<Type, List<Holder>> dic = new Dictionary<Type, List<Holder>>();
        /// <summary>
        /// 添加全局事件
        /// </summary>
        /// <typeparam name="T">事件数据类型</typeparam>
        /// <param name="listener">监听的方法</param>
        /// <param name="once">阅后即焚</param>
        public static void Add<T>(Action<T> listener,bool once = false) where T : EventArgs
        {
            if (Instance == null)
                Instance = new LynxEvents();
            var t = typeof(T);
            var holder = new Holder();
            holder.Setup(listener, once);
            AddListener(t, holder);
        }
        /// <summary>
        /// 移除全局事件
        /// </summary>
        /// <typeparam name="T">事件数据类型</typeparam>
        /// <param name="listener">监听的方法</param>
        public static void Remove<T>(Action<T> listener) where T : EventArgs
        {
            var t = typeof(T);
            if (dic.ContainsKey(t))
            {
                var list = dic[t];
                foreach (var holder in list)
                {
                    if (object.Equals(holder.raw, listener))
                    {
                        list.Remove(holder);
                        return;
                    }
                }
            }
        }

        static void RemoveListener<T>(object listener) where T : EventArgs
        {
            var t = typeof(T);
            if (dic.ContainsKey(t))
            {
                var list = dic[t];
                foreach (var holder in list)
                {
                    if (object.Equals(holder.raw, listener))
                    {
                        list.Remove(holder);
                        return;
                    }
                }
            }
        }

        static void AddListener(Type t, Holder holder)
        {
            if (!dic.ContainsKey(t))
            {
                dic[t] = new List<Holder>();
            }
            var handlers = dic[t];
            if (!handlers.Contains(holder))
            {
                handlers.Add(holder);
            }
        }
        /// <summary>
        /// 发送事件
        /// </summary>
        /// <typeparam name="T">事件数据类型</typeparam>
        /// <param name="e">传入的事件数据</param>
        public static void Send<T>(T e) where T : EventArgs
        {
            var t = typeof(T);
            if (dic.ContainsKey(t))
            {
                var handlers = dic[t];
                for (int i = 0; i < handlers.Count; i++)
                {
                    handlers[i].ex.Invoke(e);
                    if (handlers[i].once)
                        RemoveListener<T>(handlers[i].raw);
                }
            }
        }

    }

    class Holder
    {
        public object raw;
        public Action<EventArgs> ex;
        public bool once;

        public Holder() { }

        public void Setup<T>(Action<T> raw,bool once) where T : EventArgs
        {
            this.raw = raw;
            ex = CreateListener(raw);
            this.once = once;
        }

        public static Action<EventArgs> CreateListener<Args>(Action<Args> listener) where Args : EventArgs
        {
            return (args) => {
                if (null != listener)
                    listener.Invoke((Args)args);
            };
        }
    }

}

