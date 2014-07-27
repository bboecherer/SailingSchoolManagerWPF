using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingSchoolWPF.Model
{
    /// <summary>
    /// The SealingSchoolObject Model
    /// @Author Benjamin Böcherer
    /// </summary>
    public abstract class SealingSchoolObject
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public String Label { get; set; }
        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        /// <value>
        /// The additional information.
        /// </value>
        public String AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or sets the custom field1.
        /// </summary>
        /// <value>
        /// The custom field1.
        /// </value>
        public String CustomField1 { get; set; }
        /// <summary>
        /// Gets or sets the custom field2.
        /// </summary>
        /// <value>
        /// The custom field2.
        /// </value>
        public String CustomField2 { get; set; }
        /// <summary>
        /// Gets or sets the custom field3.
        /// </summary>
        /// <value>
        /// The custom field3.
        /// </value>
        public String CustomField3 { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public String CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public String ModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>
        /// The modified on.
        /// </value>
        public DateTime? ModifiedOn { get; set; }
    }
}