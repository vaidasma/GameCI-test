using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Tests
{

    public class JavaClassObjectTest //: MonoBehaviour//, IDisposable
    {
        string javaClassRef = "com.unity.statictestj.JavaPlug";
        string aarClassRef = "com.unity.statictest.JavaPlug";
        private string jarClassRef = "com.unity.statictest.jarplug.jarPlug";
        private string kotlinClassRef = "com.unity.statictestk.KotlinPlug";
        

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private readonly string TEST_STRING_GET = "1111111";
        private readonly float TEST_FLOAT_GET = 1111.1f;
        private readonly int TEST_INT_GET = 11111;
        private readonly bool TEST_BOOL_GET = true;
        private readonly double TEST_DOUBLE_GET = 1111.11;

        private readonly string TEST_STRING_SET = "222222";
        private readonly float TEST_FLOAT_SET = 2222.22f;
        private readonly int TEST_INT_SET = 2222;
        private readonly bool TEST_BOOL_SET = false;
        private readonly double TEST_DOUBLE_SET = 2222.22;

        private readonly string TEST_STRING_GET_obj = "33333333";
        private readonly float TEST_FLOAT_GET_obj = 333333.3f;
        private readonly int TEST_INT_GET_obj = 333333;
        private readonly bool TEST_BOOL_GET_obj = true;
        private readonly double TEST_DOUBLE_GET_obj = 333333.33;

        private readonly string TEST_STRING_SET_obj = "4444444";
        private readonly float TEST_FLOAT_SET_obj = 44444.4f;
        private readonly int TEST_INT_SET_obj = 444444;
        private readonly bool TEST_BOOL_SET_obj = true;
        private readonly double TEST_DOUBLE_SET_obj = 444444.44;

        private readonly int TEST_METHOD_RETURN = 55555;


        [DllImport("libnative-lib")]
        private static extern int CPP_METHODTEST_ARGUMENTS(int a);

        [DllImport("libnative-lib")]
        private static extern string CPP_TEST_STRING_GET();

        [DllImport("libnative-lib")]
        private static extern float CPP_TEST_FLOAT_GET();

        [DllImport("libnative-lib")]
        private static extern int CPP_TEST_INT_GET();

        [DllImport("libnative-lib")]
        private static extern bool CPP_TEST_BOOL_GET();

        [DllImport("libnative-lib")]
        private static extern double CPP_TEST_DOUBLE_GET();

        // <JAVA> ===========================================================================================================================================================================================
        #region  Java

        //  #region JavaClassTest
        [OneTimeSetUp]
        public void Setup()
        {
            
        }
        
        [Test] public void javaTestAndroidJavaClass_GETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test] public void javaTestAndroidJavaClass_SETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                string tempString = MyClass.GetStatic<string>("TEST_STRING");
                float tempFloat = MyClass.GetStatic<float>("TEST_FLOAT");
                int tempInt = MyClass.GetStatic<int>("TEST_INT");
                bool tempBool = MyClass.GetStatic<bool>("TEST_BOOL");
                double tempDouble = MyClass.GetStatic<double>("TEST_DOUBLE");

                MyClass.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                MyClass.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                MyClass.SetStatic<int>("TEST_INT", TEST_INT_SET);
                MyClass.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                MyClass.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                MyClass.SetStatic<string>("TEST_STRING", tempString);
                MyClass.SetStatic<float>("TEST_FLOAT", tempFloat);
                MyClass.SetStatic<int>("TEST_INT", tempInt);
                MyClass.SetStatic<bool>("TEST_BOOL", tempBool);
                MyClass.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test] public void javaTestAndroidJavaClass_CALLS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                bool testCheck = (MyClass.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (MyClass.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }
        /*
        class MyJavaClass : UnityEngine.AndroidJavaClass
        {
            public MyJavaClass() : base(aarClassRef)
            {

            }
        }

        [UnityTest]
        public IEnumerator TestAndroidJavaClass_DISPOSE()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                //AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                MyJavaClass MJC = new MyJavaClass();
                MJC.Dispose();
                yield return new WaitForSeconds(2);
                Assert.IsNull(MJC);
            }
        } */

      //  #endregion

      //  #region JavaObjectTest
        [Test] public void javaTestAndroidJavaObject_GETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test] public void javaTestAndroidJavaObject_SETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                string tempString = AJO.GetStatic<string>("TEST_STRING");
                float tempFloat = AJO.GetStatic<float>("TEST_FLOAT");
                int tempInt = AJO.GetStatic<int>("TEST_INT");
                bool tempBool = AJO.GetStatic<bool>("TEST_BOOL");
                double tempDouble = AJO.GetStatic<double>("TEST_DOUBLE");

                AJO.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                AJO.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                AJO.SetStatic<int>("TEST_INT", TEST_INT_SET);
                AJO.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                AJO.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                AJO.SetStatic<string>("TEST_STRING", tempString);
                AJO.SetStatic<float>("TEST_FLOAT", tempFloat);
                AJO.SetStatic<int>("TEST_INT", tempInt);
                AJO.SetStatic<bool>("TEST_BOOL", tempBool);
                AJO.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test] public void javaTestAndroidJavaObject_CALLS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (AJO.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }



        [Test] public void javaTestAndroidJavaObject_GET() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_GET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_GET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_GET_obj) &&
                               (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_GET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_GET_obj);
                Assert.IsTrue(testCheck);
            }
        }

        [Test] public void javaTestAndroidJavaObject_SET() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");

                string tempString = AJO.Get<string>("TEST_STRING_obj");
                float tempFloat = AJO.Get<float>("TEST_FLOAT_obj");
                int tempInt = AJO.Get<int>("TEST_INT_obj");
                bool tempBool = AJO.Get<bool>("TEST_BOOL_obj");
                double tempDouble = AJO.Get<double>("TEST_DOUBLE_obj");

                AJO.Set<string>("TEST_STRING_obj", TEST_STRING_SET_obj);
                AJO.Set<float>("TEST_FLOAT_obj", TEST_FLOAT_SET_obj);
                AJO.Set<int>("TEST_INT_obj", TEST_INT_SET_obj);
                AJO.Set<bool>("TEST_BOOL_obj", TEST_BOOL_SET_obj);
                AJO.Set<double>("TEST_DOUBLE_obj", TEST_DOUBLE_SET_obj);

                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_SET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_SET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_SET_obj) &&
                                (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_SET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_SET_obj);
                AJO.Set<string>("TEST_STRING_obj", tempString);
                AJO.Set<float>("TEST_FLOAT_obj", tempFloat);
                AJO.Set<int>("TEST_INT_obj", tempInt);
                AJO.Set<bool>("TEST_BOOL_obj", tempBool);
                AJO.Set<double>("TEST_DOUBLE_obj", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test] public void javaTestAndroidJavaObject_CALL() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(javaClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Call<int>("METHODTEST") == TEST_METHOD_RETURN) && (AJO.Call<int>("METHODTEST_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }

                /* 
        class MyJavaObject : UnityEngine.AndroidJavaObject
        {
            public MyJavaObject(): base(javaClassRef)
            {

            }
        }

        [UnityTest] public IEnumerator TestAndroidJavaObject_DISPOSE() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
             //   AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                MyJavaObject MJO = new MyJavaObject();
                MJO.Dispose();
                 GC.Collect();
                 yield return new WaitForSeconds(10);
                 GC.Collect();
                 Assert.IsNull(MJO);
            }
        }  */


        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) {
            if (disposed)
                return;

            if (disposing){
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }


        #endregion
        // <AAR> ===========================================================================================================================================================================================
        #region aar

        [Test]
        public void aarTestAndroidJavaClass_GETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void aarTestAndroidJavaClass_SETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                string tempString = MyClass.GetStatic<string>("TEST_STRING");
                float tempFloat = MyClass.GetStatic<float>("TEST_FLOAT");
                int tempInt = MyClass.GetStatic<int>("TEST_INT");
                bool tempBool = MyClass.GetStatic<bool>("TEST_BOOL");
                double tempDouble = MyClass.GetStatic<double>("TEST_DOUBLE");

                MyClass.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                MyClass.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                MyClass.SetStatic<int>("TEST_INT", TEST_INT_SET);
                MyClass.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                MyClass.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                MyClass.SetStatic<string>("TEST_STRING", tempString);
                MyClass.SetStatic<float>("TEST_FLOAT", tempFloat);
                MyClass.SetStatic<int>("TEST_INT", tempInt);
                MyClass.SetStatic<bool>("TEST_BOOL", tempBool);
                MyClass.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void aarTestAndroidJavaClass_CALLS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                bool testCheck = (MyClass.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (MyClass.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }
        /*
        class MyJavaClass : UnityEngine.AndroidJavaClass
        {
            public MyJavaClass() : base(aarClassRef)
            {

            }
        }

        [UnityTest]
        public IEnumerator TestAndroidJavaClass_DISPOSE()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                //AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                MyJavaClass MJC = new MyJavaClass();
                MJC.Dispose();
                yield return new WaitForSeconds(2);
                Assert.IsNull(MJC);
            }
        } */

        //  #endregion

      

        //  #region JavaObjectTest
        [Test]
        public void aarTestAndroidJavaObject_GETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void aarTestAndroidJavaObject_SETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                string tempString = AJO.GetStatic<string>("TEST_STRING");
                float tempFloat = AJO.GetStatic<float>("TEST_FLOAT");
                int tempInt = AJO.GetStatic<int>("TEST_INT");
                bool tempBool = AJO.GetStatic<bool>("TEST_BOOL");
                double tempDouble = AJO.GetStatic<double>("TEST_DOUBLE");

                AJO.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                AJO.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                AJO.SetStatic<int>("TEST_INT", TEST_INT_SET);
                AJO.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                AJO.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                AJO.SetStatic<string>("TEST_STRING", tempString);
                AJO.SetStatic<float>("TEST_FLOAT", tempFloat);
                AJO.SetStatic<int>("TEST_INT", tempInt);
                AJO.SetStatic<bool>("TEST_BOOL", tempBool);
                AJO.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void aarTestAndroidJavaObject_CALLS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (AJO.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }



        [Test]
        public void aarTestAndroidJavaObject_GET()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_GET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_GET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_GET_obj) &&
                               (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_GET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_GET_obj);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void aarTestAndroidJavaObject_SET()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");

                string tempString = AJO.Get<string>("TEST_STRING_obj");
                float tempFloat = AJO.Get<float>("TEST_FLOAT_obj");
                int tempInt = AJO.Get<int>("TEST_INT_obj");
                bool tempBool = AJO.Get<bool>("TEST_BOOL_obj");
                double tempDouble = AJO.Get<double>("TEST_DOUBLE_obj");

                AJO.Set<string>("TEST_STRING_obj", TEST_STRING_SET_obj);
                AJO.Set<float>("TEST_FLOAT_obj", TEST_FLOAT_SET_obj);
                AJO.Set<int>("TEST_INT_obj", TEST_INT_SET_obj);
                AJO.Set<bool>("TEST_BOOL_obj", TEST_BOOL_SET_obj);
                AJO.Set<double>("TEST_DOUBLE_obj", TEST_DOUBLE_SET_obj);

                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_SET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_SET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_SET_obj) &&
                                (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_SET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_SET_obj);
                AJO.Set<string>("TEST_STRING_obj", tempString);
                AJO.Set<float>("TEST_FLOAT_obj", tempFloat);
                AJO.Set<int>("TEST_INT_obj", tempInt);
                AJO.Set<bool>("TEST_BOOL_obj", tempBool);
                AJO.Set<double>("TEST_DOUBLE_obj", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void aarTestAndroidJavaObject_CALL()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(aarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Call<int>("METHODTEST") == TEST_METHOD_RETURN) && (AJO.Call<int>("METHODTEST_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }

        #endregion
        // <JAR> ===========================================================================================================================================================================================
        #region jar
        
        [Test]
        public void jarTestAndroidJavaClass_GETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void jarTestAndroidJavaClass_SETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                string tempString = MyClass.GetStatic<string>("TEST_STRING");
                float tempFloat = MyClass.GetStatic<float>("TEST_FLOAT");
                int tempInt = MyClass.GetStatic<int>("TEST_INT");
                bool tempBool = MyClass.GetStatic<bool>("TEST_BOOL");
                double tempDouble = MyClass.GetStatic<double>("TEST_DOUBLE");

                MyClass.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                MyClass.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                MyClass.SetStatic<int>("TEST_INT", TEST_INT_SET);
                MyClass.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                MyClass.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                MyClass.SetStatic<string>("TEST_STRING", tempString);
                MyClass.SetStatic<float>("TEST_FLOAT", tempFloat);
                MyClass.SetStatic<int>("TEST_INT", tempInt);
                MyClass.SetStatic<bool>("TEST_BOOL", tempBool);
                MyClass.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void jarTestAndroidJavaClass_CALLS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                bool testCheck = (MyClass.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (MyClass.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }
        /*
        class MyJavaClass : UnityEngine.AndroidJavaClass
        {
            public MyJavaClass() : base(jarClassRef)
            {

            }
        }

        [UnityTest]
        public IEnumerator TestAndroidJavaClass_DISPOSE()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                //AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                MyJavaClass MJC = new MyJavaClass();
                MJC.Dispose();
                yield return new WaitForSeconds(2);
                Assert.IsNull(MJC);
            }
        } */

        //  #endregion



        //  #region JavaObjectTest
        [Test]
        public void jarTestAndroidJavaObject_GETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void jarTestAndroidJavaObject_SETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                string tempString = AJO.GetStatic<string>("TEST_STRING");
                float tempFloat = AJO.GetStatic<float>("TEST_FLOAT");
                int tempInt = AJO.GetStatic<int>("TEST_INT");
                bool tempBool = AJO.GetStatic<bool>("TEST_BOOL");
                double tempDouble = AJO.GetStatic<double>("TEST_DOUBLE");

                AJO.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                AJO.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                AJO.SetStatic<int>("TEST_INT", TEST_INT_SET);
                AJO.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                AJO.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                AJO.SetStatic<string>("TEST_STRING", tempString);
                AJO.SetStatic<float>("TEST_FLOAT", tempFloat);
                AJO.SetStatic<int>("TEST_INT", tempInt);
                AJO.SetStatic<bool>("TEST_BOOL", tempBool);
                AJO.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void jarTestAndroidJavaObject_CALLS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (AJO.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }
        
        [Test]
        public void jarTestAndroidJavaObject_GET()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_GET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_GET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_GET_obj) &&
                               (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_GET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_GET_obj);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void jarTestAndroidJavaObject_SET()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");

                string tempString = AJO.Get<string>("TEST_STRING_obj");
                float tempFloat = AJO.Get<float>("TEST_FLOAT_obj");
                int tempInt = AJO.Get<int>("TEST_INT_obj");
                bool tempBool = AJO.Get<bool>("TEST_BOOL_obj");
                double tempDouble = AJO.Get<double>("TEST_DOUBLE_obj");

                AJO.Set<string>("TEST_STRING_obj", TEST_STRING_SET_obj);
                AJO.Set<float>("TEST_FLOAT_obj", TEST_FLOAT_SET_obj);
                AJO.Set<int>("TEST_INT_obj", TEST_INT_SET_obj);
                AJO.Set<bool>("TEST_BOOL_obj", TEST_BOOL_SET_obj);
                AJO.Set<double>("TEST_DOUBLE_obj", TEST_DOUBLE_SET_obj);

                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_SET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_SET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_SET_obj) &&
                                (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_SET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_SET_obj);
                AJO.Set<string>("TEST_STRING_obj", tempString);
                AJO.Set<float>("TEST_FLOAT_obj", tempFloat);
                AJO.Set<int>("TEST_INT_obj", tempInt);
                AJO.Set<bool>("TEST_BOOL_obj", tempBool);
                AJO.Set<double>("TEST_DOUBLE_obj", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test]
        public void jarTestAndroidJavaObject_CALL()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(jarClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Call<int>("METHODTEST") == TEST_METHOD_RETURN) && (AJO.Call<int>("METHODTEST_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }

        #endregion
        // <Kotlin> ===========================================================================================================================================================================================
        #region kotlin
        
        [Test]
        public void kotlinTestAndroidJavaClass_GETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                 (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }
        
        [Test]
        public void kotlinTestAndroidJavaClass_SETS()
        {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                string tempString = MyClass.GetStatic<string>("TEST_STRING");
                float tempFloat = MyClass.GetStatic<float>("TEST_FLOAT");
                int tempInt = MyClass.GetStatic<int>("TEST_INT");
                bool tempBool = MyClass.GetStatic<bool>("TEST_BOOL");
                double tempDouble = MyClass.GetStatic<double>("TEST_DOUBLE");

                MyClass.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                MyClass.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                MyClass.SetStatic<int>("TEST_INT", TEST_INT_SET);
                MyClass.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                MyClass.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (MyClass.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (MyClass.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (MyClass.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                 (MyClass.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (MyClass.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                MyClass.SetStatic<string>("TEST_STRING", tempString);
                MyClass.SetStatic<float>("TEST_FLOAT", tempFloat);
                MyClass.SetStatic<int>("TEST_INT", tempInt);
                MyClass.SetStatic<bool>("TEST_BOOL", tempBool);
                MyClass.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }
        
        [Test]
        public void kotlinTestAndroidJavaClass_CALLS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                bool testCheck = (MyClass.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (MyClass.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        } 

        
        [Test] public void kotlinTestAndroidJavaObject_GETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_GET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_GET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_GET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_GET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_GET);
                Assert.IsTrue(testCheck);
            }
        }

        [Test] public void kotlinTestAndroidJavaObject_SETS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                string tempString = AJO.GetStatic<string>("TEST_STRING");
                float tempFloat = AJO.GetStatic<float>("TEST_FLOAT");
                int tempInt = AJO.GetStatic<int>("TEST_INT");
                bool tempBool = AJO.GetStatic<bool>("TEST_BOOL");
                double tempDouble = AJO.GetStatic<double>("TEST_DOUBLE");

                AJO.SetStatic<string>("TEST_STRING", TEST_STRING_SET);
                AJO.SetStatic<float>("TEST_FLOAT", TEST_FLOAT_SET);
                AJO.SetStatic<int>("TEST_INT", TEST_INT_SET);
                AJO.SetStatic<bool>("TEST_BOOL", TEST_BOOL_SET);
                AJO.SetStatic<double>("TEST_DOUBLE", TEST_DOUBLE_SET);

                bool testCheck = (AJO.GetStatic<string>("TEST_STRING") == TEST_STRING_SET) && (AJO.GetStatic<float>("TEST_FLOAT") == TEST_FLOAT_SET) && (AJO.GetStatic<int>("TEST_INT") == TEST_INT_SET) &&
                                (AJO.GetStatic<bool>("TEST_BOOL") == TEST_BOOL_SET) && (AJO.GetStatic<double>("TEST_DOUBLE") == TEST_DOUBLE_SET);
                AJO.SetStatic<string>("TEST_STRING", tempString);
                AJO.SetStatic<float>("TEST_FLOAT", tempFloat);
                AJO.SetStatic<int>("TEST_INT", tempInt);
                AJO.SetStatic<bool>("TEST_BOOL", tempBool);
                AJO.SetStatic<double>("TEST_DOUBLE", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }


        [Test] public void kotlinTestAndroidJavaObject_CALLS() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.CallStatic<int>("METHODTEST_STATIC") == TEST_METHOD_RETURN) && (AJO.CallStatic<int>("METHODTEST_STATIC_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        }



        [Test] public void kotlinTestAndroidJavaObject_GET() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_GET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_GET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_GET_obj) &&
                               (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_GET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_GET_obj);
                Assert.IsTrue(testCheck);
            }
        }

        [Test] public void kotlinTestAndroidJavaObject_SET() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");

                string tempString = AJO.Get<string>("TEST_STRING_obj");
                float tempFloat = AJO.Get<float>("TEST_FLOAT_obj");
                int tempInt = AJO.Get<int>("TEST_INT_obj");
                bool tempBool = AJO.Get<bool>("TEST_BOOL_obj");
                double tempDouble = AJO.Get<double>("TEST_DOUBLE_obj");

                AJO.Set<string>("TEST_STRING_obj", TEST_STRING_SET_obj);
                AJO.Set<float>("TEST_FLOAT_obj", TEST_FLOAT_SET_obj);
                AJO.Set<int>("TEST_INT_obj", TEST_INT_SET_obj);
                AJO.Set<bool>("TEST_BOOL_obj", TEST_BOOL_SET_obj);
                AJO.Set<double>("TEST_DOUBLE_obj", TEST_DOUBLE_SET_obj);

                bool testCheck = (AJO.Get<string>("TEST_STRING_obj") == TEST_STRING_SET_obj) && (AJO.Get<float>("TEST_FLOAT_obj") == TEST_FLOAT_SET_obj) && (AJO.Get<int>("TEST_INT_obj") == TEST_INT_SET_obj) &&
                                (AJO.Get<bool>("TEST_BOOL_obj") == TEST_BOOL_SET_obj) && (AJO.Get<double>("TEST_DOUBLE_obj") == TEST_DOUBLE_SET_obj);
                AJO.Set<string>("TEST_STRING_obj", tempString);
                AJO.Set<float>("TEST_FLOAT_obj", tempFloat);
                AJO.Set<int>("TEST_INT_obj", tempInt);
                AJO.Set<bool>("TEST_BOOL_obj", tempBool);
                AJO.Set<double>("TEST_DOUBLE_obj", tempDouble);
                Assert.IsTrue(testCheck);
            }
        }

        [Test]
        public void kotlinTestAndroidJavaObject_CALL() {
            using (AndroidJavaClass MyClass = new AndroidJavaClass(kotlinClassRef))
            {
                AndroidJavaObject AJO = MyClass.CallStatic<AndroidJavaObject>("returnInstance");
                bool testCheck = (AJO.Call<int>("METHODTEST") == TEST_METHOD_RETURN) && (AJO.Call<int>("METHODTEST_ARGUMENTS", TEST_METHOD_RETURN) == TEST_METHOD_RETURN);
                Assert.IsTrue(testCheck);
            }
        } 
        #endregion
        // <cpp> ===========================================================================================================================================================================================
        #region cpp
        
        [Test]
        public void cppTestMethodsWithArgs()
        {
            int number = CPP_METHODTEST_ARGUMENTS(8);
            Assert.AreEqual(8, number);
        }

        /* [Test] // string marshalling is more complicated
        public void cppTestStringGET()
        {
            string number = CPP_TEST_STRING_GET();
            Assert.AreEqual(TEST_STRING_GET, number);
        } */

        [Test]
        public void cppTestFloatGET()
        {
            float number = CPP_TEST_FLOAT_GET();
            Assert.AreEqual(TEST_FLOAT_GET, number);
        }

        [Test]
        public void cppTestIntGET()
        {
            int number = CPP_TEST_INT_GET();
            Assert.AreEqual(TEST_INT_GET, number);
        }
        
        [Test]
        public void cppTestBoolGET()
        {
            bool number = CPP_TEST_BOOL_GET();
            Assert.AreEqual(TEST_BOOL_GET, number);
        }

        [Test]
        public void cppTestDoubleGET()
        {
            double number = CPP_TEST_DOUBLE_GET();
            Assert.AreEqual(TEST_DOUBLE_GET, number);
        } 
        // not freeing memory from c++ side, but it's probably irellevant in such small scope

        #endregion
    }



}