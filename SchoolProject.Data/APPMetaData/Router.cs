using System;

namespace SchoolProject.Data.APPMetaData
{
    public static class Router
    {
        private const string Root = "api";
        private const string Version = "v1";
        public const string BaseUrl = $"{Root}/{Version}";
        public static class StudentRouting
        {
            private const string Prefix = $"{BaseUrl}/students";

            // Collection endpoints
            public const string List = $"{Prefix}/List";
            public const string Create = Prefix;

            // Single resource endpoints
            public const string GetById = $"{Prefix}/{{id}}";
            public const string Update = $"{Prefix}/{{id}}";
            public const string Delete = $"{Prefix}/{{id}}";

            // Related resources
            public const string GetSubjects = $"{Prefix}/{{id}}/subjects";
            public const string AddToSubject = $"{Prefix}/{{studentId}}/subjects/{{subjectId}}";
            public const string RemoveFromSubject = $"{Prefix}/{{studentId}}/subjects/{{subjectId}}";

            public static string GetByIdRoute(int id) => $"{Prefix}/{id}";
            public static string UpdateRoute(int id) => $"{Prefix}/{id}";
            public static string DeleteRoute(int id) => $"{Prefix}/{id}";
            public static string GetSubjectsRoute(int id) => $"{Prefix}/{id}/subjects";
            public static string AddToSubjectRoute(int studentId, int subjectId) =>
                $"{Prefix}/{studentId}/subjects/{subjectId}";
            public static string RemoveFromSubjectRoute(int studentId, int subjectId) =>
                $"{Prefix}/{studentId}/subjects/{subjectId}";
        }

        public static class DepartmentRouting
        {
            private const string Prefix = $"{BaseUrl}/departments";

            // Collection endpoints
            public const string List = $"{Prefix}/List";
            public const string Create = Prefix;

            // Single resource endpoints
            public const string GetById = $"{Prefix}/{{id}}";
            public const string Update = $"{Prefix}/{{id}}";
            public const string Delete = $"{Prefix}/{{id}}";

            // Related resources
            public const string GetStudents = $"{Prefix}/{{id}}/students";
            public const string GetSubjects = $"{Prefix}/{{id}}/subjects";
            public const string AddSubject = $"{Prefix}/{{departmentId}}/subjects/{{subjectId}}";

            public static string GetByIdRoute(int id) => $"{Prefix}/{id}";
            public static string UpdateRoute(int id) => $"{Prefix}/{id}";
            public static string DeleteRoute(int id) => $"{Prefix}/{id}";
            public static string GetStudentsRoute(int id) => $"{Prefix}/{id}/students";
            public static string GetSubjectsRoute(int id) => $"{Prefix}/{id}/subjects";
            public static string AddSubjectRoute(int departmentId, int subjectId) =>
                $"{Prefix}/{departmentId}/subjects/{subjectId}";
        }

        public static class SubjectRouting
        {
            private const string Prefix = $"{BaseUrl}/subjects";

            // Collection endpoints
            public const string List = $"{Prefix}/List";
            public const string Create = Prefix;

            // Single resource endpoints
            public const string GetById = $"{Prefix}/{{id}}";
            public const string Update = $"{Prefix}/{{id}}";
            public const string Delete = $"{Prefix}/{{id}}";

            // Related resources
            public const string GetStudents = $"{Prefix}/{{id}}/students";
            public const string GetDepartment = $"{Prefix}/{{id}}/department";

            public static string GetByIdRoute(int id) => $"{Prefix}/{id}";
            public static string UpdateRoute(int id) => $"{Prefix}/{id}";
            public static string DeleteRoute(int id) => $"{Prefix}/{id}";
            public static string GetStudentsRoute(int id) => $"{Prefix}/{id}/students";
            public static string GetDepartmentRoute(int id) => $"{Prefix}/{id}/department";
        }
    }
}