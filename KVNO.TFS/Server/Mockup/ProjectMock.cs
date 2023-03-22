namespace KVNO.TFS.Server.Mockup
{
    public class ProjectMock
    {
        public DevOpsProject[] GetProjectsMockups()
        {
            var list = new List<DevOpsProject>();

            // Collection 1 -  b2d72ea7-1d85-405c-a8b0-c916de0a4df4
            var p11 = new DevOpsProject("5e66c86e-07e1-4400-a352-499b4031c5c4", "Project1", "-", DateTime.Now, "b2d72ea7-1d85-405c-a8b0-c916de0a4df4");
            var p12 = new DevOpsProject("9f22e185-477f-40c4-82f6-3afdbe4effcc", "Project2", "-", DateTime.Now, "b2d72ea7-1d85-405c-a8b0-c916de0a4df4");
            var p13 = new DevOpsProject("25c20ce8-02f0-4a6b-9afd-0059ee97f9d3", "Project3", "-", DateTime.Now, "b2d72ea7-1d85-405c-a8b0-c916de0a4df4");
            var p14 = new DevOpsProject("216ab3df-0e2a-40cc-b508-0af588bfa53b", "Project4", "-", DateTime.Now, "b2d72ea7-1d85-405c-a8b0-c916de0a4df4");
            var p15 = new DevOpsProject("bc21e385-8c16-4542-8942-bee3979d891e", "Project5", "-", DateTime.Now, "b2d72ea7-1d85-405c-a8b0-c916de0a4df4");

            // Collection 2 -  f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9
            var p21 = new DevOpsProject("eb8e8ab4-2540-4b64-a923-9dcdf4be581d", "Project1", "-", DateTime.Now, "f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9");
            var p22 = new DevOpsProject("72eff1bf-822b-454b-b8fb-35feef8f67f1", "Project2", "-", DateTime.Now, "f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9");
            var p23 = new DevOpsProject("34fef5f4-26b5-4f54-9ec4-ecf89d023a9d", "Project3", "-", DateTime.Now, "f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9");
            var p24 = new DevOpsProject("82d52a3d-22ea-4605-b888-4c9ff9f0bc17", "Project4", "-", DateTime.Now, "f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9");
            var p25 = new DevOpsProject("bb3b0fe2-ce86-4c60-92af-bc7dc9f3950c", "Project5", "-", DateTime.Now, "f51d0f4b-56d2-40e5-8b17-fbca93cf3bb9");


            // Collection 3 -  3e57a5b0-dd25-46a1-845b-9028b2aa96a6
            var p31 = new DevOpsProject("b0e27595-028b-4759-aabc-b7f0cac37766", "Project1", "-", DateTime.Now, "3e57a5b0-dd25-46a1-845b-9028b2aa96a6");
            var p32 = new DevOpsProject("24afb033-1c37-4806-b4ca-3468755ffe9b", "Project2", "-", DateTime.Now, "3e57a5b0-dd25-46a1-845b-9028b2aa96a6");
            var p33 = new DevOpsProject("423fae92-d67b-4a9a-a86a-749a1d29a90c", "Project3", "-", DateTime.Now, "3e57a5b0-dd25-46a1-845b-9028b2aa96a6");
            var p34 = new DevOpsProject("affdb13e-23fa-4ab7-a5fc-c57bca78e60b", "Project4", "-", DateTime.Now, "3e57a5b0-dd25-46a1-845b-9028b2aa96a6");
            var p35 = new DevOpsProject("8c05cb98-077c-4d7b-8cf3-768c7956369f", "Project5", "-", DateTime.Now, "3e57a5b0-dd25-46a1-845b-9028b2aa96a6");

            list.Add(p11);
            list.Add(p12);
            list.Add(p13);
            list.Add(p14);
            list.Add(p15);

            list.Add(p21);
            list.Add(p22);
            list.Add(p23);
            list.Add(p24);
            list.Add(p25);

            list.Add(p31);
            list.Add(p32);
            list.Add(p33);
            list.Add(p34);
            list.Add(p35);

            return list.ToArray();
        }
    }
}
