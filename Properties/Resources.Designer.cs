﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calc.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Calc.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似于 (Icon) 的 System.Drawing.Icon 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Icon Code {
            get {
                object obj = ResourceManager.GetObject("Code", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 E	返回算术常量 e，即自然对数的底数（约等于2.718）
        ///LN2	返回 2 的自然对数（约等于0.693）
        ///LN10	返回 10 的自然对数（约等于2.302）
        ///LOG2E	返回以 2 为底的 e 的对数（约等于 1.4426950408889634）
        ///LOG10E	返回以 10 为底的 e 的对数（约等于0.434）
        ///PI	返回圆周率（约等于3.14159）
        ///SQRT1_2	返回 2 的平方根的倒数（约等于 0.707）
        ///SQRT2	返回 2 的平方根（约等于 1.414）
        ///abs(x)	返回 x 的绝对值
        ///acos(x)	返回 x 的反余弦值
        ///asin(x)	返回 x 的反正弦值
        ///atan(x)	以介于 -PI/2 与 PI/2 弧度之间的数值来返回 x 的反正切值
        ///atan2(y,x)	返回从 x 轴到点 (x,y) 的角度（介于 -PI/2 与 PI/2 弧度之间）
        ///ceil(x)	对数进行上舍入
        ///cos(x)	返回数的余弦
        ///exp(x)	返回 Ex 的指数
        ///floor(x)	对 x 进行下舍入
        ///log(x)	返回数的自然对数（底为e）
        ///max(x,y,z,... [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string Help {
            get {
                return ResourceManager.GetString("Help", resourceCulture);
            }
        }
    }
}
