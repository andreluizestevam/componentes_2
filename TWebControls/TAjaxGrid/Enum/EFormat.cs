using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    /// <summary>
    /// http://www.trirand.net/documentation/php/_2v70wa4jv.htm
    /// </summary>
    public enum EFormat
    {
        /// <summary>
        /// thousandsSeparator determines the separator for the thousands, defaultValue set the default value if nothing in the data
        /// </summary>
        Integer,

        /// <summary>
        /// thousandsSeparator determines the separator for the thousands, decimalSeparator determines the separator for the decimals, decimalPlaces determine how many decimal places we should have for the number, defaultValue set the default value if nothing in the data
        /// </summary>
        Number,

        /// <summary>
        /// The same as number, but we add aditional two options - prefix a text the is puted before the number and suffix the text that is added after the number
        /// </summary>
        Currency,

        /// <summary>
        /// srcformat is the source format - i.e. the format of the date that should be converted, newformat is the new output format. The definition of the date format uses the PHP conversions. Also you can use a set of predefined date format - see the mask options in the default date formatting set
        /// </summary>
        Date,

        /// <summary>
        /// When a mail type is used we directly add a href with mailto: before the e-mail
        /// </summary>
        Email,

        /// <summary>
        /// The default value of the target options is null. When this options is set, we construct a link with the target property set and the cell value put in the href tag.
        /// </summary>
        Link,

        /// <summary>
        /// baseLinkUrl is the link. 
        ///showAction is an additional value which is added after the baseLinkUrl. 
        ///addParam is an additional parameter that can be added after the
        ///idName property. target, if set, is added as an additional attribute. 
        //idName is the first parameter that is added after the showAction. By default, this is id,
        /// </summary>
        ShowLink,

        /// <summary>
        /// The default value for the disabled is true. This option determines if the checkbox can be changed. If set to false, the values in checkbox can be changed
        /// </summary>
        CheckBox,

        /// <summary>
        /// This is not a real select but a special case. See note below
        /// </summary>
        Select
    }
}
