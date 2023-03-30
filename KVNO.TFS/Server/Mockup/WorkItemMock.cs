namespace KVNO.TFS.Server.Mockup
{
    public class WorkItemMock
    {
        public DevOpsWorkItem[] GetWorkItemsMockup()
        {
            string[] users = {"Diaz, Isaac","De la Cruz, Elvia", "Storozhenko, Libid", "Laurila, Otto", "Hansen, Christian" };

            var list = new List<DevOpsWorkItem>();

            //Projekt 1-1 - 5e66c86e-07e1-4400-a352-499b4031c5c4

            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"5e66c86e-07e1-4400-a352-499b4031c5c4-{i}", $"Task{i}", users[i-1],"Closed","Task","Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0,5,5, "5e66c86e-07e1-4400-a352-499b4031c5c4");
                list.Add(t);
            }

            //Projekt 1-2 - 9f22e185-477f-40c4-82f6-3afdbe4effcc
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"9f22e185-477f-40c4-82f6-3afdbe4effcc-{i}", $"Task{i}", users[i-1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "9f22e185-477f-40c4-82f6-3afdbe4effcc");
                list.Add(t);
            }
            //Projekt 1-3 - 25c20ce8-02f0-4a6b-9afd-0059ee97f9d3
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"25c20ce8-02f0-4a6b-9afd-0059ee97f9d3-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 5, 5, "25c20ce8-02f0-4a6b-9afd-0059ee97f9d3");
                list.Add(t);
            }
            //Projekt 1-4 - 216ab3df-0e2a-40cc-b508-0af588bfa53b
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"216ab3df-0e2a-40cc-b508-0af588bfa53b-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "216ab3df-0e2a-40cc-b508-0af588bfa53b");
                list.Add(t);
            }
            //Projekt 1-5 - bc21e385-8c16-4542-8942-bee3979d891e
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"bc21e385-8c16-4542-8942-bee3979d891e-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 8, 5, "bc21e385-8c16-4542-8942-bee3979d891e");
                list.Add(t);
            }

            //Projekt 2-1 - eb8e8ab4-2540-4b64-a923-9dcdf4be581d
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"eb8e8ab4-2540-4b64-a923-9dcdf4be581d-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "eb8e8ab4-2540-4b64-a923-9dcdf4be581d");
                list.Add(t);
            }
            //Projekt 2-2 - 72eff1bf-822b-454b-b8fb-35feef8f67f1
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"72eff1bf-822b-454b-b8fb-35feef8f67f1-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 10, 5, "72eff1bf-822b-454b-b8fb-35feef8f67f1");
                list.Add(t);
            }
            //Projekt 2-3 - 34fef5f4-26b5-4f54-9ec4-ecf89d023a9d
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"34fef5f4-26b5-4f54-9ec4-ecf89d023a9d-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "34fef5f4-26b5-4f54-9ec4-ecf89d023a9d");
                list.Add(t);
            }
            //Projekt 2-4 - 82d52a3d-22ea-4605-b888-4c9ff9f0bc17
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"82d52a3d-22ea-4605-b888-4c9ff9f0bc17-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "82d52a3d-22ea-4605-b888-4c9ff9f0bc17");
                list.Add(t);
            }
            //Projekt 2-5 - bb3b0fe2-ce86-4c60-92af-bc7dc9f3950c
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"bb3b0fe2-ce86-4c60-92af-bc7dc9f3950c-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "bb3b0fe2-ce86-4c60-92af-bc7dc9f3950c");
                list.Add(t);
            }

            //Projekt 3-1 - b0e27595-028b-4759-aabc-b7f0cac37766
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"b0e27595-028b-4759-aabc-b7f0cac37766-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "b0e27595-028b-4759-aabc-b7f0cac37766");
                list.Add(t);
            }
            //Projekt 3-2 - 24afb033-1c37-4806-b4ca-3468755ffe9b
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"24afb033-1c37-4806-b4ca-3468755ffe9b-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "24afb033-1c37-4806-b4ca-3468755ffe9b");
                list.Add(t);
            }
            //Projekt 3-3 - 423fae92-d67b-4a9a-a86a-749a1d29a90c
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"423fae92-d67b-4a9a-a86a-749a1d29a90c-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "423fae92-d67b-4a9a-a86a-749a1d29a90c");
                list.Add(t);
            }
            //Projekt 3-4 - affdb13e-23fa-4ab7-a5fc-c57bca78e60b
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"affdb13e-23fa-4ab7-a5fc-c57bca78e60b-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "affdb13e-23fa-4ab7-a5fc-c57bca78e60b");
                list.Add(t);
            }
            //Projekt 3-5 - 8c05cb98-077c-4d7b-8cf3-768c7956369f
            for (int i = 1; i <= 5; i++)
            {
                var t = new DevOpsWorkItem($"8c05cb98-077c-4d7b-8cf3-768c7956369f-{i}", $"Task{i}", users[i - 1], "Closed", "Task", "Completed", DateTime.Now, DateTime.Now, DateTime.Now, 0, 3, 5, "8c05cb98-077c-4d7b-8cf3-768c7956369f");
                list.Add(t);
            }

            return list.ToArray();
        }
    }
}
