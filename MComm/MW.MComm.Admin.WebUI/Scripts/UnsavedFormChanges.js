// A simple boolean
var _isFormDirty = false; 

function SetFormChanged(changed)
{
    _isFormDirty = changed;
}

function PromptToDiscardChanges()
{
    var result;
    
    if (_isFormDirty)
    {
        result = window.confirm("Changes have not been saved. Continue?");
        return result;
    }   
    else
        return true;

}

function ConfirmDelete()
{
    return window.confirm("Are you sure you want to delete this item?");
}

function ConfirmRemove()
{
    return window.confirm("Are you sure you want to remove this item?");
}

