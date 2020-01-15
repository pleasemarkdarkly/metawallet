
function debug(s1)
{
  //alert(s1);
}



String.prototype.trim = function()
{
    // Use a regular expression to replace leading and trailing 
    // spaces with the empty string
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

var HelpMgr = {
  m_helpSections : null,
  
  register : function(content)
  {
      debug(content);
    if(HelpMgr.m_helpSections == null)
      HelpMgr.m_helpSections = new Array();
    

    HelpMgr.m_helpSections[HelpMgr.m_helpSections.length] = content;
  },
  
  init : function()
  {
  debug('init');

    if(HelpMgr.m_helpSections == null)
      HelpMgr.m_helpSections = new Array();

    var link = document.getElementById('HelpLink');
    var hasContent = false;
    if(link != null)
    {
      for(var i=0;i<HelpMgr.m_helpSections.length;i++)
      {
          var contentId = HelpMgr.m_helpSections[i];
          var content = document.getElementById(contentId);
          hasContent = hasContent || (content != null && content.innerHTML.trim().length > 0);
          if(hasContent)
            break;
      }

      link.style.display = hasContent ? "block" : "none";      
      if(hasContent)
      {
          link.onclick = HelpMgr.toggleDisplayAll;
      }
        
    }
  },
  
  toggleDisplay : function(id)
  {
    var e = document.getElementById(id);
    e.style.display = (e.style.display == "none") ? "block" : "none";
    return 0;
  },
  
  toggleDisplayAll : function()
  {
    debug('toggleDisplayAll');
    for(var i=0;i<HelpMgr.m_helpSections.length;i++)
    {
      var content = document.getElementById(HelpMgr.m_helpSections[i]);
      if(content != null)
      {
        content.style.display = (content.style.display == "none") ? "block" : "none";
      }
    }
    return 0;
  }
};

function body_onload()
{
  debug('body_onload');
  HelpMgr.init();     
}

function inputbox(id, text)
{
  var val = prompt(text,document.getElementById(id).value);
  if(val == null)
  {
    window.event.cancelBubble = true;
    window.event.returnValue = false;
    return false;
  }
  
  var ele = document.getElementById(id);
  ele.value = val;
  
  return true;
}
function SizeForm() 
{  
  var winW = document.documentElement.clientWidth;
  theForm.style.width = winW;
}