using UnityEngine;
using System.Collections;

public class Attribute {
    public double initial;  //基础属性
    public double final {   //最终属性
        get {
            return calculateFinal();
        }
    }
    public double value;    //修正比
    public double ratio;    //修正值
    public string name;     //属性名

    private double calculateFinal() {
        return initial * (1 + ratio * 0.001) + value;
    }
}
