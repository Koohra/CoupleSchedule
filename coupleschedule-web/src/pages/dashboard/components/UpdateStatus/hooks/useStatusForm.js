import { useState } from 'react';
import api from '../../../../../services/api';

export function useStatusForm(onStatusUpdated) {
  const [activity, setActivity] = useState('');
  const [focus, setFocus] = useState(0);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put('/partners/update-status', { 
        Activity: activity, 
        FocusId: parseInt(focus) 
      });
      setActivity('');
      setFocus(0);
      onStatusUpdated();
    } catch (err) { 
      console.error(err); 
    }
  };

  return {
    activity,
    focus,
    handlers: {
      setActivity,
      setFocus,
      handleSubmit
    }
  };
}

export const focusOptions = [
  { id: 0, label: 'Nenhum', color: 'hover:bg-gray-100' },
  { id: 1, label: 'Leve', color: 'hover:bg-emerald-50 text-emerald-600' },
  { id: 2, label: 'Foco Total', color: 'hover:bg-orange-50 text-orange-500' }
];