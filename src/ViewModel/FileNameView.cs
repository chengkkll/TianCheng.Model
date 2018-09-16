using System;
using System.Collections.Generic;
using System.Text;

namespace TianCheng.Model
{
    /// <summary>
    /// 文件名称信息查看对象
    /// </summary>
    public class FileNameView
    {
        /// <summary>
        /// 磁盘根路径
        /// </summary>
        public string DiskRoot { get; set; }
        /// <summary>
        /// 网络根路径
        /// </summary>
        public string WebRoot { get; set; }
        /// <summary>
        /// 磁盘存放路径
        /// </summary>
        public string DiskPath { get; set; }
        /// <summary>
        /// 网络存放路径
        /// </summary>
        public string WebPath { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtName { get; set; }
        /// <summary>
        /// 磁盘路径全名
        /// </summary>
        public string DiskFileFullName { get; set; }
        /// <summary>
        /// 网络路径全名
        /// </summary>
        public string WebFileFullName { get; set; }
    }
}
