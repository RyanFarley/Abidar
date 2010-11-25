using System;
using System.Collections.Generic;
using System.Text;
using Abidar.Components;
using System.Xml;

namespace Abidar
{
    public class TaskScheduler
    {
        #region Fields

        public static List<Task> _tasks = null;
        private XmlNodeList _nodes = null;

        #endregion

        #region Public Constructors

        public TaskScheduler(XmlNodeList nodes)
        {
            this._nodes = nodes;
            Initialize();
        }

        #endregion

        #region Public Methods

        public void StartTasks()
        {
            foreach (Task task in _tasks)
            {
                if (!task.IsRunning)
                    task.Start();
            }
        }

        public void StopTasks()
        {
            foreach (Task task in _tasks)
            {
                task.Stop();
            }
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            _tasks = new List<Task>();

            foreach (XmlNode node in this._nodes)
            {
                if (node.Name == "Task")
                {
                    try
                    {
                        XmlAttributeCollection attributes = node.Attributes;

                        if (bool.Parse(attributes["enabled"].Value))
                        {
                            Task task = new Task(double.Parse(attributes["interval"].Value));

                            task.Name = attributes["name"].Value;
                            task.TaskType = Type.GetType(attributes["type"].Value, true);
                            task.Enabled = bool.Parse(attributes["enabled"].Value);
                            task.Priority = (Priority)Convert.ToInt16(attributes["priority"].Value);
                            task.ConfigurationNode = node;

                            _tasks.Add(task);
                        }
                    }
                    catch
                    {
                        // Handle the exception
                        // Usually log a warning in event log
                    }
                }
            }
        }

        #endregion
    }
}
