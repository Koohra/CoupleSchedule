import { motion } from 'framer-motion';

const colorClasses = {
  indigo: "bg-indigo-100 text-indigo-600",
  orange: "bg-orange-100 text-orange-600",
  emerald: "bg-emerald-100 text-emerald-600"
};

export function StatItem({ label, value, icon, color }) {
  return (
    <motion.div
      whileHover={{ scale: 1.05 }}
      className={`${colorClasses[color]} rounded-2xl p-4 text-center cursor-pointer transition-all`}
    >
      <span className="text-2xl mb-2 block">{icon}</span>
      <p className="text-lg font-bold">{value}</p>
      <p className="text-[10px] uppercase tracking-widest opacity-70">{label}</p>
    </motion.div>
  );
}