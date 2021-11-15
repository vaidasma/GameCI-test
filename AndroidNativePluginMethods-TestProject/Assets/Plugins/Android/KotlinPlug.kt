package com.unity.statictestk;
import android.util.Log;

public class KotlinPlug {

    companion object {
        @JvmStatic
        var classInstance: KotlinPlug = KotlinPlug()
    
        @JvmStatic
        fun returnInstance(): KotlinPlug{
        return classInstance
        }
    
        @JvmStatic
        fun METHODTEST_STATIC(): Int {
            return 55555;
        }
        @JvmStatic
        fun METHODTEST_STATIC_ARGUMENTS(a: Int): Int {
            Log.d("AAA", "EEEEEEEEEEEEEEEEEEEE2")
            return a;
        }
        
        @JvmStatic
        var TEST_STRING: String = "1111111"
        @JvmStatic
        var TEST_FLOAT: Float = 1111.1f
        @JvmStatic
        var TEST_INT: Int = 11111
        @JvmStatic
        var TEST_BOOL: Boolean = true
        @JvmStatic
        var TEST_DOUBLE: Double = 1111.11      
    }
    
    var TEST_STRING_obj: String = "33333333"
    var TEST_FLOAT_obj: Float = 333333.3f
    var TEST_INT_obj: Int = 333333
    var TEST_BOOL_obj: Boolean = true
    var TEST_DOUBLE_obj: Double = 333333.33
            
    fun METHODTEST(): Int {
        return 55555;
    }
    fun METHODTEST_ARGUMENTS(a: Int): Int {
        Log.d("AAA", "CCCCCCCCCC")
        return a;
    }

}


