import { useStatusForm } from './hooks/useStatusForm';
import { ActivityInput } from './ActivityInput';
import { FocusSelector } from './FocusSelector';
import { SubmitButton } from './SubmitButton';

export function UpdateStatus({ onStatusUpdated }) {
  const { activity, focus, handlers } = useStatusForm(onStatusUpdated);

  return (
    <form onSubmit={handlers.handleSubmit} className="space-y-8">
      <ActivityInput 
        value={activity} 
        onChange={handlers.setActivity} 
      />
      
      <FocusSelector 
        value={focus} 
        onChange={handlers.setFocus} 
      />
      
      <SubmitButton />
    </form>
  );
}