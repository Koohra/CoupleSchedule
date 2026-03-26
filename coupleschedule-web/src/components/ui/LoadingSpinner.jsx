import { motion } from 'framer-motion';

export function LoadingSpinner() {
  return (
    <motion.div
      animate={{ rotate: 360 }}
      transition={{ duration: 2, repeat: Infinity, ease: "linear" }}
      className="w-12 h-12 border-4 border-indigo-200 border-t-indigo-500 rounded-full"
    />
  );
}