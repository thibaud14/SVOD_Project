class CreateRefProfessions < ActiveRecord::Migration
  def change
    create_table :ref_professions do |t|
      t.string :name

      t.timestamps
    end
  end
end
